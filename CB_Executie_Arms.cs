using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anthrax;
using Anthrax.WoW.Internals;
using System.Timers;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.Threading;
using System.Xml;
//using System.Xml.Linq;
//using System.Data;

/////////////////////////////////////////////////////////////////////////////////////
//                                                                                 //
//                   ##################                                            //
//                   #                #                                            //
//                   #    ___         #     _   _                                  //
//                   #   / __|  ___   #  __| | (_)  _ _    __ _                    // 
//                   #  | (__  / _ \  # / _` | | | | ' \  / _` |                   //
//                   #   \___| \___/  # \__,_| |_| |_||_| \__, |                   // 
//                   #                #                   |___/                    //  
//                   #                #                                            //
//                   ###################################                           //
//                                    #                #                           //
//                                    #      ___       #            _              //
//                                    #     | _ )      #  __ _   __| |             //
//                                    #     | _ \      # / _` | / _` |             //
//                                    #     |___/      # \__,_| \__,_|             //
//                                    #                #                           //
//                                    #                #                           //
//                                    ##################                           //
//                                                                                 //
//                            Executie Arms Warrior                                //
/////////////////////////////////////////////////////////////////////////////////////
// Support Thread: http://goo.gl/xc1vZ3

namespace Anthrax
{
    public class CB_Executie_Arms : Anthrax.Modules.ICombat  //This file must be copied inside the CombatClass folder
    {
        #region private vars
        private System.Timers.Timer wndCloser = new System.Timers.Timer(2000);
        bool isAOE;
        
        #endregion

        [DllImport("User32.dll")] 
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey); // Keys enumeration 
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        #region importSettings
        public int SW_HP, DbtS_HP, DBa_HP, DBa_key, DSt_HP, DSt_key, RC_HP, RC_key, ER_HP, IVSG_HP, HStone_HP, SBa_key, Ralg_key, AOE_tars, AOE_key, T4Talent_key, HL_key, Pause_key, RE_Immers_stacks;
        public bool SW_use, DbtS_use, DBa_use, DSt_use, RC_use, ER_use, IVSG_use, HStone_use, ST_use, SBa_use, Race_use, AV_use, RE_use, Pot_use, Eng_use, Ralg_use, AOE_use, Intrpt_use, RE_Immers_use, RE_Nazg_use;
        public string SMode;
        string CharacterLoggedIn = ObjectManager.LocalPlayer.Name;
        public void GetSettingsFromXML()
        {

            XmlDocument doc = new XmlDocument();
            string CharPath = "Combats\\CB_Executie\\CB_Executie_Arms_" + CharacterLoggedIn + ".xml";
            if (File.Exists(CharPath))
            {
                doc.Load(CharPath);
                Anthrax.Logger.WriteLine("Executie - Loaded Settings for " + CharacterLoggedIn);
            }
            else
            {
                doc.Load("Combats\\CB_Executie\\CB_Executie_Arms_default.xml");
                Anthrax.Logger.WriteLine("Executie - Loaded default Settings");
            }
            
            //Werte Lesen XML
            
            //DefCDs
            SW_HP = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/DefCD/Shieldwall_HP").InnerText);
            DbtS_HP = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/DefCD/DieByTheSword_HP").InnerText);
            DBa_HP = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/DefCD/Demobanner_HP").InnerText);
            DSt_HP = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/DefCD/DefStance_HP").InnerText);
            RC_HP = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/DefCD/RallyingCry_HP").InnerText);
            ER_HP = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/DefCD/EnragedRegeneration_HP").InnerText);
            IVSG_HP = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/DefCD/Intervene_HP").InnerText);
            HStone_HP = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/DefCD/Healthstone_HP").InnerText);
            SW_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/DefCD/Shieldwall_Use").InnerText);
            DbtS_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/DefCD/DieByTheSword_Use").InnerText);
            DBa_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/DefCD/Demobanner_Use").InnerText);
            DSt_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/DefCD/DefStance_Use").InnerText);
            RC_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/DefCD/RallyingCry_Use").InnerText);
            ER_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/DefCD/EnragedRegeneration_Use").InnerText);
            IVSG_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/DefCD/Intervene_Use").InnerText);
            HStone_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/DefCD/Healthstone_Use").InnerText);
            ST_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/DefCD/ShatteringThrow_Use").InnerText); //zu offensive
            
            //OffCds
            SBa_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/OffCD/Skullbanner_use").InnerText);
            Race_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/OffCD/Racial_use").InnerText);
            AV_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/OffCD/Avatar_use").InnerText);
            RE_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/OffCD/Recklessness_use").InnerText);
            Pot_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/OffCD/DPSPotion_use").InnerText);
            Eng_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/OffCD/SynapseSprings_use").InnerText);
            Ralg_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/OffCD/RunAwayLittleGirl_use").InnerText);
            
            //Misc
            AOE_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/misc/AoE_use").InnerText);
            AOE_tars = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/misc/AoE_count").InnerText);
            SMode = Convert.ToString(doc.SelectSingleNode("ExecutieSettings/misc/Shoutmode").InnerText);
            
            //Raidevents
            RE_Immers_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/raid_events/Immerseus_HC_use").InnerText);
            RE_Immers_stacks = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/raid_events/Immerseus_HC_count").InnerText);
            RE_Nazg_use = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/raid_events/Nazgrim_HC").InnerText);
            
        }               
        #endregion

        #region enums
        public enum Spells : int
        {
            AV = 107574,            //Avatar
            BE = 26297,             //Berserk (Troll)
            BB = 12292,             //Blood Bath
            BF = 20572,             //Blood Fury (Orc)
            BR = 18499,             //Berserker Rage
            BS = 46924,             //Blade Storm
            BSh = 6673,             //Battle Shout
            BSt = 2457,             //Battle Stance
            CH = 100,               //Charge
            CL = 845,               //Cleave
            CS = 86346,             //Colossus Smash
            CSh = 469,               //Commanding Shout
            DA = 676,               //Disarm
            DBa = 14203,            //Demoralizing Banner
            DbtS = 118038,          //Die by the Sword
            DR = 118000,            //Dragon Roar
            DS = 102060,            //Disrupting Shout
            DSt = 71,               //Defensive Stance 7376
            EnR = 12880,            //Enrage
            ER = 55694,             //Enraged Regeneration
            EX = 5308,              //Execute
            HaS = 1715,             //Harmstring
            HL = 6544,              //Heroic Leap
            HS = 78,                //Heroic Strike
            HT = 57755,             //Heroic Throw
            ISh = 5246,             //Intimidating Shout
            IV = 3411,              //Intervene
            IVc = 103840,           //Impending Victory
            MS = 12294,             //Mortal Strike
            OP = 7384,              //Overpower
            PU = 6552,              //Pummel
            RC = 97462,             //Rallying Cry
            RE = 1719,              //Recklessness
            SB = 107570,            //Storm Bold
            SBa = 114207,           //Skull Banner
            SG = 114029,            //Safeguard
            SL = 1464,              //Slam
            SR = 23920,             //Spell Reflection
            SS = 12328,             //Sweeping Strikes
            ST = 64382,             //Shattering Throw
            SW = 871,               //Shield Wall
            SWv = 46968,            //Shockwave
            TC = 6343,              //Thunder Clap
            VL = 114030,            //Vigilance
            VR = 34428,             //Victory Rush  
            WW = 1680,              //Whirlwind
        }

        public enum Auras : int
        {
            BBA = 12292,            //Blood Bath Aura
            BShA = 6673,            //Battle Shout Aura
            CSdb = 86346,           //CSmash Debuff
            CShA = 69,              //Commanding Shout Aura
            DS = 144442,            //Death Sentence
            DWdb = 115767,          //Deep Wounds Debuff
            EnR = 12880,            //Enrage
            REb = 1719,             //Recklessness Aura
            SBaA = 114206,          //SkullBanner Aura
            SE = 139958,            //Sudden Execute
            SoOCrit = 146285,       //Crit Proc of Skeers Trinket, Stacking to 20
            SSA = 12328,            //Sweeping Strikes Aura
            T162P = 144438,         //T16 2 Piece Bonus
            TfB = 56636,            //Taste for Blood

            BLust = 2825,           //Bloodlust
            HRoism = 32182,         //Heroism
            TWarp = 80353,          //Timewarp
            AHysteria = 90355,      //Ancient Hysteria
            NWinds = 160452,        //Netherwinds
        }
        
        public enum Items : int
        {
            MoguPot = 76095,        //Potion of Mogu Power
            HStone = 5512,          //Healthstone
        }
        #endregion

        #region VirtualKeys
        int key_LMouse = 1;
        int key_RMouse = 2;
        int key_MMouse = 4;
        int key_SHIFT = 16;
        int key_CTRL = 17;
        int key_ALT = 18;
        int key_0 = 48;
        int key_1 = 49;
        int key_2 = 50;
        int key_3 = 51;
        int key_4 = 52;
        int key_5 = 53;
        int key_6 = 54;
        int key_7 = 55;
        int key_8 = 56;
        int key_9 = 57;
        int key_A = 65;
        int key_B = 66;
        int key_C = 67;
        int key_D = 68;
        int key_E = 69;
        int key_F = 70;
        int key_G = 71;
        int key_H = 72;
        int key_I = 73;
        int key_J = 74;
        int key_K = 75;
        int key_L = 76;
        int key_M = 77;
        int key_N = 78;
        int key_O = 79;
        int key_P = 80;
        int key_Q = 81;
        int key_R = 82;
        int key_S = 83;
        int key_T = 84;
        int key_U = 85;
        int key_V = 86;
        int key_W = 87;
        int key_X = 88;
        int key_Y = 89;
        int key_Z = 90;
        int key_F1 = 112;
        int key_F2 = 113;
        int key_F3 = 114;
        int key_F4 = 115;
        int key_F5 = 116;
        int key_F6 = 117;
        int key_F7 = 118;
        int key_F8 = 119;
        int key_F9 = 120;
        int key_F10 = 121;
        int key_F11 = 122;
        int key_F12 = 123;
        #endregion

        #region BloodlustCheck
        //Check for Bloodlust
        public bool hasLust()
        {
            if (ObjectManager.LocalPlayer.HasAuraById((int)Auras.BLust) ||ObjectManager.LocalPlayer.HasAuraById((int)Auras.HRoism) ||ObjectManager.LocalPlayer.HasAuraById((int)Auras.TWarp) ||ObjectManager.LocalPlayer.HasAuraById((int)Auras.AHysteria) ||ObjectManager.LocalPlayer.HasAuraById((int)Auras.NWinds))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        public override string Name
        {
            get { return "Executie Arms by CodingBad"; }     //This name is displayed inside Anthrax
        }

        #region OnPull
        public override void OnPull(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)             
        {
            //Check if we are in BattleStance, if not, switch to
            if (ObjectManager.LocalPlayer.ShapeshiftForm != Anthrax.WoW.Classes.ObjectManager.WowUnit.WowShapeshiftForm.BattleStance &&
               Anthrax.AI.Controllers.Spell.CanUseShapeshiftForm((int)Spells.BSt))
            {
                Anthrax.Logger.WriteLine("Enter Battle Stance ...");
                Anthrax.AI.Controllers.Spell.UseShapeshiftForm((int)Spells.BSt);
                return;
            }
            
            //Charge if in range
            if (unit.Position.Distance3DFromPlayer >= 7 && unit.Position.Distance3DFromPlayer <= 28)                                         
            {
                // No need to move anymore
                AI.Controllers.Mover.StopMoving();

                // We always want to face the target
                WoW.Internals.Movements.Face(unit.Position);

                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.CH))
                {
                    Anthrax.Logger.WriteLine("Pull - Charge");                
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.CH, unit);     
                    return;
                }

            }

            //Target is too far, move closer
            else
            {
                Anthrax.AI.Controllers.Mover.MoveToObject(unit);                                 
            }
        }
        #endregion

        #region Defensives
        public void Defensives(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)
        {
            //Battle / Defensive Stance
            if (DSt_use)
            {
                if (ObjectManager.LocalPlayer.HealthPercent <= DSt_HP)
                {
                    if (ObjectManager.LocalPlayer.ShapeshiftForm != Anthrax.WoW.Classes.ObjectManager.WowUnit.WowShapeshiftForm.DefensiveStance && Anthrax.AI.Controllers.Spell.CanUseShapeshiftForm((int)Spells.DSt))
                    {
                        Anthrax.Logger.WriteLine("Enter Defensive Stance ...");
                        Anthrax.AI.Controllers.Spell.UseShapeshiftForm((int)Spells.DSt);
                        return;
                    }
                }
                else
                {
                    if (ObjectManager.LocalPlayer.ShapeshiftForm != Anthrax.WoW.Classes.ObjectManager.WowUnit.WowShapeshiftForm.BattleStance && Anthrax.AI.Controllers.Spell.CanUseShapeshiftForm((int)Spells.BSt))
                    {
                        Anthrax.Logger.WriteLine("Enter Battle Stance ...");
                        Anthrax.AI.Controllers.Spell.UseShapeshiftForm((int)Spells.BSt);
                        return;
                    }
                }
            }

            //Rallying Cry
            if (RC_use)
            {
                if (ObjectManager.LocalPlayer.HealthPercent < RC_HP &&
                        AI.Controllers.Spell.CanCast((int)Spells.RC))
                {
                    AI.Controllers.Spell.Cast((int)Spells.RC, ObjectManager.LocalPlayer);
                    return;
                }
            }

            //Shield Wall
            if (SW_use)
            {
                if (ObjectManager.LocalPlayer.HealthPercent < SW_HP &&
                        AI.Controllers.Spell.CanCast((int)Spells.SW))
                {
                    AI.Controllers.Spell.Cast((int)Spells.SW, ObjectManager.LocalPlayer);
                    return;
                }
            }

            //Die by the Sword
            if (DbtS_use)
            {
                if (ObjectManager.LocalPlayer.HealthPercent < DbtS_HP &&
                        AI.Controllers.Spell.CanCast((int)Spells.DbtS))
                {
                    AI.Controllers.Spell.Cast((int)Spells.DbtS, ObjectManager.LocalPlayer);
                    return;
                }
            }

            //Demo Banner
            if (DBa_use)
            {
                if (ObjectManager.LocalPlayer.HealthPercent < DBa_HP &&
                        AI.Controllers.Spell.CanCast((int)Spells.DBa))
                {
                    AI.Controllers.Spell.Cast((int)Spells.DBa, ObjectManager.LocalPlayer);
                    return;
                }
            }

            //Enraged Regeneration
            if (ER_use)
            {
                if (ObjectManager.LocalPlayer.HealthPercent < ER_HP &&
                        AI.Controllers.Spell.CanCast((int)Spells.ER))
                {
                    AI.Controllers.Spell.Cast((int)Spells.ER, ObjectManager.LocalPlayer);
                    return;
                }
            }

        }
        #endregion

        #region Offensives
        public void Offensives(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)
        {
            //actions+=/mogu_power_potion,if=(target.health.pct<20&buff.recklessness.up)|buff.bloodlust.react|target.time_to_die<=25
            if (Pot_use)
            {
                if ((unit.HealthPercent < 20 && ObjectManager.LocalPlayer.HasAuraById((int)Auras.REb)) || hasLust())
                {
                    Anthrax.Logger.WriteLine("Using Mogu Potion");
                    Anthrax.AI.Controllers.Inventory.UseItemById((int)Items.MoguPot);
                }
            }

            //RECK AUF CD -> OPTIMIEREN
            if (RE_use)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.RE))
                {
                    Anthrax.Logger.WriteLine("Casting Recklessness");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.RE, ObjectManager.LocalPlayer);
                }
            }

            //actions+=/avatar,if=enabled&(buff.recklessness.up|target.time_to_die<=25)
            if (AV_use)
            {
                if(ObjectManager.LocalPlayer.HasAuraById((int)Auras.REb))
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.AV))
                    {
                        Anthrax.Logger.WriteLine("Casting Avatar");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.AV, ObjectManager.LocalPlayer);
                    }
                }
            }

            //actions+=/skull_banner,if=buff.skull_banner.down&(((cooldown.colossus_smash.remains<2|debuff.colossus_smash.remains>=5)&target.time_to_die>192&buff.cooldown_reduction.up)|buff.recklessness.up)
            if (SBa_use)
            {
                if (!ObjectManager.LocalPlayer.HasAuraById((int)Auras.SBaA))
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.SBa))
                    {
                        Anthrax.Logger.WriteLine("Casting Skull Banner");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.SBa, ObjectManager.LocalPlayer);
                    }
                }
            }

            ////actions+=/use_item,slot=hands,if=!talent.bloodbath.enabled&debuff.colossus_smash.up|buff.bloodbath.up
            //if (Eng_use)
            //{
            //    if (unit.HasAuraById((int)Auras.CSdb) || ObjectManager.LocalPlayer.HasAuraById((int)Auras.BBA))
            //    {
            //        if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.SBa))
            //        {
            //            Anthrax.Logger.WriteLine("Casting Skull Banner");
            //            Anthrax.AI.Controllers.Spell.Cast((int)Spells.SBa);
            //        }
            //    }
            //}

            //actions+=/blood_fury,if=buff.cooldown_reduction.down&(buff.bloodbath.up|(!talent.bloodbath.enabled&debuff.colossus_smash.up))|buff.cooldown_reduction.up&buff.recklessness.up
            //actions+=/berserking,if=buff.cooldown_reduction.down&(buff.bloodbath.up|(!talent.bloodbath.enabled&debuff.colossus_smash.up))|buff.cooldown_reduction.up&buff.recklessness.up
            if (Race_use)
            {
                if (ObjectManager.LocalPlayer.HasAuraById((int)Auras.BBA) || (unit.HasAuraById((int)Auras.CSdb) || ObjectManager.LocalPlayer.HasAuraById((int)Auras.REb)))
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.BF))
                    {
                        Anthrax.Logger.WriteLine("Casting Blood Fury (Orc)");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.BF, ObjectManager.LocalPlayer);
                    }
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.BE))
                    {
                        Anthrax.Logger.WriteLine("Casting Berserk (Troll)");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.BE, ObjectManager.LocalPlayer);
                    }
                }
            }

            //actions+=/bloodbath,if=enabled&(debuff.colossus_smash.remains>0.1|cooldown.colossus_smash.remains<5|target.time_to_die<=20)
            if (unit.HasAuraById((int)Auras.CSdb))
            {
                if (unit.Auras.Where(x => x.SpellId == (int)Auras.CSdb).First().TimeLeft > 100)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.BB))
                    {
                        Anthrax.Logger.WriteLine("Casting Blood Bath");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.BB, ObjectManager.LocalPlayer);
                    }
                }
            }
            
            //actions+=/berserker_rage,if=buff.enrage.remains<0.5
            if (ObjectManager.LocalPlayer.HasAuraById((int)Auras.EnR))
            {
                if (ObjectManager.LocalPlayer.Auras.Where(x => x.SpellId == (int)Auras.EnR).First().TimeLeft < 500)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.BR))
                    {
                        Anthrax.Logger.WriteLine("Casting Berserker Rage");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.BR, ObjectManager.LocalPlayer);
                    }
                }
            }
            if (!ObjectManager.LocalPlayer.HasAuraById((int)Auras.EnR))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.BR))
                {
                    Anthrax.Logger.WriteLine("Casting Berserker Rage");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.BR, ObjectManager.LocalPlayer);
                }
            }


            //actions+=/heroic_leap

        }
        #endregion

        #region Singletarget
        public void SingleTargetRotation(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)               
        {
            //We always want to face the target
            WoW.Internals.Movements.Face(unit.Position);           

            //actions.single_target=heroic_strike,if=rage>115|(debuff.colossus_smash.up&rage>60&set_bonus.tier16_2pc_melee)
            if (ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 115 || (unit.HasAuraById((int)Auras.CSdb) && ObjectManager.LocalPlayer.HasAuraById((int)Auras.T162P) && ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 60))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.HS))
                {
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.HS, unit);
                    Anthrax.Logger.WriteLine("Casting - Heroic Strike");
                    return;
                }
            }
            
            //actions.single_target+=/mortal_strike,if=dot.deep_wounds.remains<1.0|buff.enrage.down|rage<10        
            if (unit.HasAuraById((int)Auras.DWdb))
            {
                if (unit.Auras.Where(x => x.SpellId == (int)Auras.DWdb).First().TimeLeft <= 1000)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.MS))
                        {
                            Anthrax.AI.Controllers.Spell.Cast((int)Spells.MS, unit);
                            Anthrax.Logger.WriteLine("Casting - Mortal Strike");
                            return;
                        }
                }
            }
            
            if (!ObjectManager.LocalPlayer.HasAuraById((int)Auras.EnR) || ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) < 10)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.MS))
                {
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.MS, unit);
                    Anthrax.Logger.WriteLine("Casting - Mortal Strike");
                    return;
                }
            }

            //actions.single_target+=/colossus_smash,if=debuff.colossus_smash.remains<1.0
            if (!unit.HasAuraById((int)Auras.CSdb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.CS))
                    {
                        Anthrax.Logger.WriteLine("Casting - Colossus Smash");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.CS, unit);
                        return;
                    }
            }

            if (unit.HasAuraById((int)Auras.CSdb))
            {
                if (unit.Auras.Where(x => x.SpellId == (int)Auras.CSdb).First().TimeLeft <= 1000)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.CS))
                    {
                        Anthrax.Logger.WriteLine("Casting - Colossus Smash");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.CS, unit);
                        return;
                    }
                }
            }

            //actions.single_target+=/mortal_strike
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.MS))
                {
                    Anthrax.Logger.WriteLine("Casting - Mortal Strike");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.MS, unit);
                    return;
                }

                //actions.single_target+=/storm_bolt,if=enabled&debuff.colossus_smash.up
                if (unit.HasAuraById((int)Auras.CSdb))
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.SB))
                    {
                        Anthrax.Logger.WriteLine("Casting - Storm Bolt");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.SB, unit);
                        return;
                    }
                }

                //actions.single_target+=/dragon_roar,if=enabled&debuff.colossus_smash.down
                if (!unit.HasAuraById((int)Auras.CSdb))
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.DR))
                    {
                        Anthrax.Logger.WriteLine("Casting - Dragon Roar");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.DR, unit);
                        return;
                    }
                }

                //actions.single_target+=/execute,if=buff.sudden_execute.down|buff.taste_for_blood.down|rage>90|target.time_to_die<12
                if (!ObjectManager.LocalPlayer.HasAuraById((int)Auras.SE) || !unit.HasAuraById((int)Auras.TfB) || ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 90)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.EX))
                    {
                        Anthrax.Logger.WriteLine("Casting - Execute");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.EX, unit);
                        return;
                    }
                }

                //# Slam is preferable to overpower with crit procs/recklessness.
                //actions.single_target+=/slam,if=target.health.pct>=20&(trinket.stacking_stat.crit.stack>=10|buff.recklessness.up)
                if (ObjectManager.LocalPlayer.HasAuraById((int)Auras.SoOCrit))
                {
                    if (unit.HealthPercent > 20 && (ObjectManager.LocalPlayer.Auras.Where(x => x.SpellId == (int)Auras.SoOCrit).First().StackCount >= 10))
                    {
                        if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.SL))
                        {
                            Anthrax.Logger.WriteLine("Casting - Slam");
                            Anthrax.AI.Controllers.Spell.Cast((int)Spells.SL, unit);
                            return;
                        }
                    }
                }
                if (ObjectManager.LocalPlayer.HasAuraById((int)Auras.REb))
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.SL))
                    {
                        Anthrax.Logger.WriteLine("Casting - Slam");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.SL, unit);
                        return;
                    }
                }

                //actions.single_target+=/overpower,if=target.health.pct>=20&rage<100|buff.sudden_execute.up
                if ((unit.HealthPercent > 20 && ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) < 100) || ObjectManager.LocalPlayer.HasAuraById((int)Auras.SE))
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.OP))
                    {
                        Anthrax.Logger.WriteLine("Casting - Overpower");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.OP, unit);
                        return;
                    }
                }

                //actions.single_target+=/execute
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.EX))
                {
                    Anthrax.Logger.WriteLine("Casting - Excute");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.EX, unit);
                    return;
                }

                //actions.single_target+=/slam,if=target.health.pct>=20
                if (unit.HealthPercent > 20)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.SL))
                    {
                        Anthrax.Logger.WriteLine("Casting - Slam");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.SL, unit);
                        return;
                    }
                }

                //actions.single_target+=/heroic_throw
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.HT))
                {
                    Anthrax.Logger.WriteLine("Casting - Heroic Throw");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.HT, unit);
                    return;
                }

                //actions.single_target+=/battle_shout
                if (Convert.ToString(SMode) == "battleshout")
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.BSh))
                    {
                        Anthrax.Logger.WriteLine("Casting - Battle Shout");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.BSh, unit);
                        return;
                    }
                }

                if (Convert.ToString(SMode) == "commandingshout")
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.CSh))
                    {
                        Anthrax.Logger.WriteLine("Casting - Commanding Shout");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.CSh, unit);
                        return;
                    }
                }

            //Nothing else to fire, using autottack
            Anthrax.AI.Controllers.Spell.AttackTarget();

            
        }
        #endregion

        #region Multitarget
        public void MultiTargetRotation(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)
        {
                        
            // We always want to face the target
            WoW.Internals.Movements.Face(unit.Position);

            //actions.aoe=sweeping_strikes
            if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.SS))
            {
                Anthrax.Logger.WriteLine("Casting - Sweeping Strikes");
                Anthrax.AI.Controllers.Spell.Cast((int)Spells.SS, unit);
                return;
            }

            //actions.aoe+=/cleave,if=rage>110&active_enemies<=4
            if (ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 110)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.CL))
                {
                    Anthrax.Logger.WriteLine("Casting - Cleave");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.CL, unit);
                    return;
                }
            }

            //actions.aoe+=/bladestorm,if=enabled&(buff.bloodbath.up|!talent.bloodbath.enabled)
            if (ObjectManager.LocalPlayer.HasAuraById((int)Auras.BBA))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.BS))
                {
                    Anthrax.Logger.WriteLine("Casting - Bladestorm");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.BS, unit);
                    return;
                }
            }

            //actions.aoe+=/dragon_roar,if=enabled&debuff.colossus_smash.down
            if (!unit.HasAuraById((int)Auras.CSdb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.DR))
                {
                    Anthrax.Logger.WriteLine("Casting - Dragon Roar");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.DR, unit);
                    return;
                }
            }

            //actions.aoe+=/colossus_smash,if=debuff.colossus_smash.remains<1
            if (!unit.HasAuraById((int)Auras.CSdb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.CS))
                {
                    Anthrax.Logger.WriteLine("Casting - Colossus Smash 3");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.CS, unit);
                    return;
                }
            }

            if (unit.HasAuraById((int)Auras.CSdb))
            {
                if (unit.Auras.Where(x => x.SpellId == (int)Auras.CSdb).First().TimeLeft <= 1000)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.CS))
                    {
                        Anthrax.Logger.WriteLine("Casting - Colossus Smash 3");
                        Anthrax.AI.Controllers.Spell.Cast((int)Spells.CS, unit);
                        return;
                    }
                }
            }

            //actions.aoe+=/thunder_clap
            if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.TC))
            {
                Anthrax.Logger.WriteLine("Casting - Thunder Clap");
                Anthrax.AI.Controllers.Spell.Cast((int)Spells.TC, unit);
                return;
            }

            //actions.aoe+=/mortal_strike,if=active_enemies=2|rage<50
            if (ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) < 50)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.MS))
                {
                    Anthrax.Logger.WriteLine("Casting - Mortal Strike");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.MS, unit);
                    return;
                }
            }

            //actions.aoe+=/execute,if=buff.sudden_execute.down&active_enemies=2
            if (!ObjectManager.LocalPlayer.HasAuraById((int)Auras.SE))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.EX))
                {
                    Anthrax.Logger.WriteLine("Casting - Excute");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.EX, unit);
                    return;
                }
            }

            //actions.aoe+=/slam,if=buff.sweeping_strikes.up&debuff.colossus_smash.up
            if (ObjectManager.LocalPlayer.HasAuraById((int)Auras.SSA) && unit.HasAuraById((int)Auras.CSdb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.SL))
                {
                    Anthrax.Logger.WriteLine("Casting - Slam");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.SL, unit);
                    return;
                }
            }

            //actions.aoe+=/overpower,if=active_enemies=2
            if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.OP))
            {
                Anthrax.Logger.WriteLine("Casting - Overpower");
                Anthrax.AI.Controllers.Spell.Cast((int)Spells.OP, unit);
                return;
            }

            //actions.aoe+=/slam,if=buff.sweeping_strikes.up
            if (ObjectManager.LocalPlayer.HasAuraById((int)Auras.SSA))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.SL))
                {
                    Anthrax.Logger.WriteLine("Casting - Slam");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.SL, unit);
                    return;
                }
            }

            //actions.aoe+=/battle_shout
            if (Convert.ToString(SMode) == "battleshout")
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.BSh))
                {
                    Anthrax.Logger.WriteLine("Casting - Battle Shout 13");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.BSh, unit);
                    return;
                }
            }

            if (Convert.ToString(SMode) == "commandingshout")
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.CSh))
                {
                    Anthrax.Logger.WriteLine("Casting - Commanding Shout 13");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.CSh, unit);
                    return;
                }
            }

            //Nothing else to fire, using autottack
            Anthrax.AI.Controllers.Spell.AttackTarget();

            
        }
        #endregion

        #region Rotation Change
        public void changeRotation()
        {
            if (isAOE)
            {
                isAOE = false;
                Anthrax.Logger.WriteLine("Singletarget Rotation");
            }
            else
            {
                isAOE = true;
                Anthrax.Logger.WriteLine("Multitarget Rotation");
            }
        }
        #endregion

        #region Overrides
        public override void OnLoad()
        {            
            GetSettingsFromXML();
        }

        public override void OnCombat(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)
        {

            Offensives(unit);
            Defensives(unit);
            if (ObjectManager.LocalPlayer.UnitsAttackingMe.Count >= AOE_tars)
            {
                MultiTargetRotation(unit);
                
            }
            else
            {
                SingleTargetRotation(unit);
                
            }

            //if (isAOE) 
            //{
            //    MultiTargetRotation(unit);  
            //}
            //else
            //{
            //    SingleTargetRotation(unit); 
            //}
            //if ((GetAsyncKeyState(90) == -32767))
            //{
            //    changeRotation();
            //}
        }

        public override void Settings()
        {
            string XMLCheck = "Combats\\CB_Executie\\CB_Executie_Arms_"+CharacterLoggedIn+".xml";
            if (!File.Exists(XMLCheck))
            {
                File.Copy("Combats\\CB_Executie\\CB_Executie_Arms_default.xml", "Combats\\CB_Executie\\CB_Executie_Arms_"+CharacterLoggedIn+".xml");
                Anthrax.Logger.WriteLine("Executie - Created Settings for " + CharacterLoggedIn);
            }
            else if (File.Exists(XMLCheck))
            {
                Anthrax.Logger.WriteLine("Executie - Loaded Settings for " + CharacterLoggedIn);
            }
            else
            {
                Anthrax.Logger.WriteLine("Executie - Loaded Default Settings");
            }
                
            
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "Combats\\CB_Executie\\executie_mUI.exe";
            startInfo.Arguments = CharacterLoggedIn;
            Process.Start(startInfo);        
            
        }
        #endregion

    }
}


//actions+=/mogu_power_potion,if=(target.health.pct<20&buff.recklessness.up)|buff.bloodlust.react|target.time_to_die<=25
//actions+=/recklessness,if=!talent.bloodbath.enabled&((cooldown.colossus_smash.remains<2|debuff.colossus_smash.remains>=5)&(target.time_to_die>(192*buff.cooldown_reduction.value)
//|target.health.pct<20))|buff.bloodbath.up&(target.time_to_die>(192*buff.cooldown_reduction.value)|target.health.pct<20)|target.time_to_die<=12

//actions+=/avatar,if=enabled&(buff.recklessness.up|target.time_to_die<=25)
//actions+=/skull_banner,if=buff.skull_banner.down&(((cooldown.colossus_smash.remains<2|debuff.colossus_smash.remains>=5)&target.time_to_die>192&buff.cooldown_reduction.up)|buff.recklessness.up)
//actions+=/use_item,slot=hands,if=!talent.bloodbath.enabled&debuff.colossus_smash.up|buff.bloodbath.up
//actions+=/blood_fury,if=buff.cooldown_reduction.down&(buff.bloodbath.up|(!talent.bloodbath.enabled&debuff.colossus_smash.up))|buff.cooldown_reduction.up&buff.recklessness.up
//actions+=/berserking,if=buff.cooldown_reduction.down&(buff.bloodbath.up|(!talent.bloodbath.enabled&debuff.colossus_smash.up))|buff.cooldown_reduction.up&buff.recklessness.up
//actions+=/arcane_torrent,if=buff.cooldown_reduction.down&(buff.bloodbath.up|(!talent.bloodbath.enabled&debuff.colossus_smash.up))|buff.cooldown_reduction.up&buff.recklessness.up
//actions+=/bloodbath,if=enabled&(debuff.colossus_smash.remains>0.1|cooldown.colossus_smash.remains<5|target.time_to_die<=20)
//actions+=/berserker_rage,if=buff.enrage.remains<0.5
//actions+=/heroic_leap,if=debuff.colossus_smash.up
//actions+=/run_action_list,name=aoe,if=active_enemies>=2
//actions+=/run_action_list,name=single_target,if=active_enemies<2

//actions.single_target=heroic_strike,if=rage>115|(debuff.colossus_smash.up&rage>60&set_bonus.tier16_2pc_melee)
//actions.single_target+=/mortal_strike,if=dot.deep_wounds.remains<1.0|buff.enrage.down|rage<10
//actions.single_target+=/colossus_smash,if=debuff.colossus_smash.remains<1.0
//# Use cancelaura (in-game) to stop bladestorm if CS comes off cooldown during it for any reason.
//actions.single_target+=/bladestorm,if=enabled,interrupt_if=!cooldown.colossus_smash.remains
//actions.single_target+=/mortal_strike
//actions.single_target+=/storm_bolt,if=enabled&debuff.colossus_smash.up
//actions.single_target+=/dragon_roar,if=enabled&debuff.colossus_smash.down
//actions.single_target+=/execute,if=buff.sudden_execute.down|buff.taste_for_blood.down|rage>90|target.time_to_die<12
//# Slam is preferable to overpower with crit procs/recklessness.
//actions.single_target+=/slam,if=target.health.pct>=20&(trinket.stacking_stat.crit.stack>=10|buff.recklessness.up)
//actions.single_target+=/overpower,if=target.health.pct>=20&rage<100|buff.sudden_execute.up
//actions.single_target+=/execute
//actions.single_target+=/slam,if=target.health.pct>=20
//actions.single_target+=/heroic_throw
//actions.single_target+=/battle_shout

//actions.aoe=sweeping_strikes
//actions.aoe+=/cleave,if=rage>110&active_enemies<=4
//actions.aoe+=/bladestorm,if=enabled&(buff.bloodbath.up|!talent.bloodbath.enabled)
//actions.aoe+=/dragon_roar,if=enabled&debuff.colossus_smash.down
//actions.aoe+=/colossus_smash,if=debuff.colossus_smash.remains<1
//actions.aoe+=/thunder_clap,target=2,if=dot.deep_wounds.attack_power*1.1<stat.attack_power
//actions.aoe+=/mortal_strike,if=active_enemies=2|rage<50
//actions.aoe+=/execute,if=buff.sudden_execute.down&active_enemies=2
//actions.aoe+=/slam,if=buff.sweeping_strikes.up&debuff.colossus_smash.up
//actions.aoe+=/overpower,if=active_enemies=2
//actions.aoe+=/slam,if=buff.sweeping_strikes.up
//actions.aoe+=/battle_shout