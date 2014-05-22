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
//                        Executie DPS Warrior CC for Anthrax                      //
/////////////////////////////////////////////////////////////////////////////////////
// Support Thread: http://goo.gl/xc1vZ3

namespace Anthrax
{

    #region CB_Executie
    public class CB_Executie
    {

        #region importSettings
        public static int SW_HP, DbtS_HP, DBa_HP, DBa_key, DSt_HP, DSt_key, RC_HP, RC_key, ER_HP, IVSG_HP, HStone_HP, SBa_key, Ralg_key, AOE_tars, AOE_key, T4Talent_key, HL_key, Pause_key, RE_Immers_stacks;
        public static bool SW_use, DbtS_use, DBa_use, DSt_use, RC_use, ER_use, IVSG_use, HStone_use, ST_use, SBa_use, Race_use, AV_use, RE_use, Pot_use, Eng_use, Ralg_use, AOE_use, Intrpt_use, RE_Immers_use, RE_Nazg_use;
        public static string SMode;
        public static string CharacterLoggedIn = ObjectManager.LocalPlayer.Name;
        public static void GetSettingsFromXML()
        {

            XmlDocument doc = new XmlDocument();
            string CharPath = "Combats\\CB_Executie\\CB_Executie_" + CharacterLoggedIn + ".xml";
            if (File.Exists(CharPath))
            {
                doc.Load(CharPath);
                Anthrax.Logger.WriteLine("Executie - Loaded Settings for " + CharacterLoggedIn);
            }
            else
            {
                doc.Load("Combats\\CB_Executie\\CB_Executie_default.xml");
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
            BT = 23881,             //Bloodthirst
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
            RB = 85288,             //Raging Blow
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
            WS = 100130,            //Wild Strike
            WW = 1680,              //Whirlwind
        }

        public enum Auras : int
        {
            BBA = 12292,            //Blood Bath Aura
            BShA = 6673,            //Battle Shout Aura
            BSuA = 46915,            //Bloodsurge Aura 
            CSdb = 86346,           //CSmash Debuff
            CShA = 69,              //Commanding Shout Aura
            DS = 144442,            //Death Sentence
            DWdb = 115767,          //Deep Wounds Debuff
            EnR = 12880,            //Enrage
            MCA = 12950,            //Meat Cleaver Aura
            RBA = 131116,           //Raging Blow Aura
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
        public static bool hasLust()
        {
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.BLust) || ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.HRoism) || ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.TWarp) || ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.AHysteria) || ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.NWinds))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region CD_Reduction_Trinket
        public static bool CD_Reduction_Trinket()
        {
            if (ObjectManager.LocalPlayer.EquippedItems.Where(x => x.ItemId == 104993).Any()) //LFR
            {
                return true;
            }
            else if (ObjectManager.LocalPlayer.EquippedItems.Where(x => x.ItemId == 104744).Any()) //Flex
            {
                return true;
            }
            else if (ObjectManager.LocalPlayer.EquippedItems.Where(x => x.ItemId == 102298).Any()) //Normal
            {
                return true;
            }
            else if (ObjectManager.LocalPlayer.EquippedItems.Where(x => x.ItemId == 105242).Any()) //Normal Warforged
            {
                return true;
            }
            else if (ObjectManager.LocalPlayer.EquippedItems.Where(x => x.ItemId == 104495).Any()) //Heroic
            {
                return true;
            }
            else if (ObjectManager.LocalPlayer.EquippedItems.Where(x => x.ItemId == 105491).Any()) //Heroic Warforged
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Defensives
        public static void Defensives(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)
        {
            //Battle / Defensive Stance
            if (DSt_use)
            {
                if (ObjectManager.LocalPlayer.HealthPercent <= DSt_HP)
                {
                    if (ObjectManager.LocalPlayer.ShapeshiftForm != Anthrax.WoW.Classes.ObjectManager.WowUnit.WowShapeshiftForm.DefensiveStance && Anthrax.AI.Controllers.Spell.CanUseShapeshiftForm((int)CB_Executie.Spells.DSt))
                    {
                        Anthrax.Logger.WriteLine("Enter Defensive Stance ...");
                        Anthrax.AI.Controllers.Spell.UseShapeshiftForm((int)CB_Executie.Spells.DSt);
                        return;
                    }
                }
                else
                {
                    if (ObjectManager.LocalPlayer.ShapeshiftForm != Anthrax.WoW.Classes.ObjectManager.WowUnit.WowShapeshiftForm.BattleStance && Anthrax.AI.Controllers.Spell.CanUseShapeshiftForm((int)CB_Executie.Spells.BSt))
                    {
                        Anthrax.Logger.WriteLine("Enter Battle Stance ...");
                        Anthrax.AI.Controllers.Spell.UseShapeshiftForm((int)CB_Executie.Spells.BSt);
                        return;
                    }
                }
            }

            //Rallying Cry
            if (RC_use)
            {
                if (ObjectManager.LocalPlayer.HealthPercent < RC_HP &&
                        AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.RC))
                {
                    AI.Controllers.Spell.Cast((int)CB_Executie.Spells.RC, ObjectManager.LocalPlayer);
                    return;
                }
            }

            //Shield Wall
            if (SW_use)
            {
                if (ObjectManager.LocalPlayer.HealthPercent < SW_HP &&
                        AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SW))
                {
                    AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SW, ObjectManager.LocalPlayer);
                    return;
                }
            }

            //Die by the Sword
            if (DbtS_use)
            {
                if (ObjectManager.LocalPlayer.HealthPercent < DbtS_HP &&
                        AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.DbtS))
                {
                    AI.Controllers.Spell.Cast((int)CB_Executie.Spells.DbtS, ObjectManager.LocalPlayer);
                    return;
                }
            }

            //Demo Banner
            if (DBa_use)
            {
                if (ObjectManager.LocalPlayer.HealthPercent < DBa_HP &&
                        AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.DBa))
                {
                    AI.Controllers.Spell.Cast((int)CB_Executie.Spells.DBa, ObjectManager.LocalPlayer);
                    return;
                }
            }

            //Enraged Regeneration
            if (ER_use)
            {
                if (ObjectManager.LocalPlayer.HealthPercent < ER_HP &&
                        AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.ER))
                {
                    AI.Controllers.Spell.Cast((int)CB_Executie.Spells.ER, ObjectManager.LocalPlayer);
                    return;
                }
            }

        }
        #endregion

        #region Offensives
        public static void Offensives(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)
        {
            //actions+=/mogu_power_potion,if=(target.health.pct<20&buff.recklessness.up)|buff.bloodlust.react|target.time_to_die<=25
            if (Pot_use)
            {
                if ((unit.HealthPercent < 20 && ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.REb)) || hasLust())
                {
                    Anthrax.Logger.WriteLine("Using Mogu Potion");
                    Anthrax.AI.Controllers.Inventory.UseItemById((int)Items.MoguPot);
                }
            }

            //RECK AUF CD -> OPTIMIEREN
            if (RE_use)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.RE))
                {
                    Anthrax.Logger.WriteLine("Casting - Recklessness");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.RE, ObjectManager.LocalPlayer);
                }
            }

            //actions+=/avatar,if=enabled&(buff.recklessness.up|target.time_to_die<=25)
            if (AV_use)
            {
                if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.REb))
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.AV))
                    {
                        Anthrax.Logger.WriteLine("Casting - Avatar");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.AV, ObjectManager.LocalPlayer);
                    }
                }
            }

            //actions+=/skull_banner,if=buff.skull_banner.down&(((cooldown.colossus_smash.remains<2|debuff.colossus_smash.remains>=5)&target.time_to_die>192&buff.cooldown_reduction.up)|buff.recklessness.up)
            if (SBa_use)
            {
                if (!ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.SBaA))
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SBa))
                    {
                        Anthrax.Logger.WriteLine("Casting - Skull Banner");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SBa, ObjectManager.LocalPlayer);
                    }
                }
            }

            ////actions+=/use_item,slot=hands,if=!talent.bloodbath.enabled&debuff.colossus_smash.up|buff.bloodbath.up
            //if (Eng_use)
            //{
            //    if (unit.HasAuraById((int)CB_Executie.Auras.CSdb) || ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.BBA))
            //    {
            //        if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SBa))
            //        {
            //            Anthrax.Logger.WriteLine("Casting Skull Banner");
            //            Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SBa);
            //        }
            //    }
            //}

            //actions+=/blood_fury,if=buff.cooldown_reduction.down&(buff.bloodbath.up|(!talent.bloodbath.enabled&debuff.colossus_smash.up))|buff.cooldown_reduction.up&buff.recklessness.up
            //actions+=/berserking,if=buff.cooldown_reduction.down&(buff.bloodbath.up|(!talent.bloodbath.enabled&debuff.colossus_smash.up))|buff.cooldown_reduction.up&buff.recklessness.up
            if (Race_use)
            {
                if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.BBA) || (unit.HasAuraById((int)CB_Executie.Auras.CSdb) || ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.REb)))
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BF))
                    {
                        Anthrax.Logger.WriteLine("Casting - Blood Fury (Orc)");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BF, ObjectManager.LocalPlayer);
                    }
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BE))
                    {
                        Anthrax.Logger.WriteLine("Casting - Berserk (Troll)");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BE, ObjectManager.LocalPlayer);
                    }
                }
            }

            //actions+=/bloodbath,if=enabled&(debuff.colossus_smash.remains>0.1|cooldown.colossus_smash.remains<5|target.time_to_die<=20)
            if (unit.HasAuraById((int)CB_Executie.Auras.CSdb))
            {
                if (unit.Auras.Where(x => x.SpellId == (int)CB_Executie.Auras.CSdb).First().TimeLeft > 100)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BB))
                    {
                        Anthrax.Logger.WriteLine("Casting - Blood Bath");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BB, ObjectManager.LocalPlayer);
                    }
                }
            }

            //actions+=/berserker_rage,if=buff.enrage.remains<0.5
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.EnR))
            {
                if (ObjectManager.LocalPlayer.Auras.Where(x => x.SpellId == (int)CB_Executie.Auras.EnR).First().TimeLeft < 500)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BR))
                    {
                        Anthrax.Logger.WriteLine("Casting - Berserker Rage");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BR, ObjectManager.LocalPlayer);
                    }
                }
            }
            if (!ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.EnR))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BR))
                {
                    Anthrax.Logger.WriteLine("Casting - Berserker Rage");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BR, ObjectManager.LocalPlayer);
                }
            }


            //actions+=/heroic_leap

        }
        #endregion

    }
    #endregion

    #region CB_Executie_Arms
    public class CB_Executie_Arms : Anthrax.Modules.ICombat  //This file must be copied inside the CombatClass folder
    {
        #region private vars
        bool isAOE;
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey); // Keys enumeration 
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
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
               Anthrax.AI.Controllers.Spell.CanUseShapeshiftForm((int)CB_Executie.Spells.BSt))
            {
                Anthrax.Logger.WriteLine("Enter Battle Stance ...");
                Anthrax.AI.Controllers.Spell.UseShapeshiftForm((int)CB_Executie.Spells.BSt);
                return;
            }

            //Charge if in range
            if (unit.Position.Distance3DFromPlayer >= 7 && unit.Position.Distance3DFromPlayer <= 28)
            {
                // No need to move anymore
                AI.Controllers.Mover.StopMoving();

                // We always want to face the target
                WoW.Internals.Movements.Face(unit.Position);

                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CH))
                {
                    Anthrax.Logger.WriteLine("Pull - Charge");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CH, unit);
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

        #region SingletargetArms
        public void SingleTargetRotationArms(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)
        {
            //We always want to face the target
            WoW.Internals.Movements.Face(unit.Position);

            //actions.single_target=heroic_strike,if=rage>115|(debuff.colossus_smash.up&rage>60&set_bonus.tier16_2pc_melee)
            if (ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 115 || (unit.HasAuraById((int)CB_Executie.Auras.CSdb) && ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.T162P) && ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 60))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.HS))
                {
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.HS, unit);
                    Anthrax.Logger.WriteLine("Casting - Heroic Strike");
                    return;
                }
            }

            //actions.single_target+=/mortal_strike,if=dot.deep_wounds.remains<1.0|buff.enrage.down|rage<10        
            if (unit.HasAuraById((int)CB_Executie.Auras.DWdb))
            {
                if (unit.Auras.Where(x => x.SpellId == (int)CB_Executie.Auras.DWdb).First().TimeLeft <= 1000)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.MS))
                    {
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.MS, unit);
                        Anthrax.Logger.WriteLine("Casting - Mortal Strike");
                        return;
                    }
                }
            }

            if (!ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.EnR) || ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) < 10)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.MS))
                {
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.MS, unit);
                    Anthrax.Logger.WriteLine("Casting - Mortal Strike");
                    return;
                }
            }

            //actions.single_target+=/colossus_smash,if=debuff.colossus_smash.remains<1.0
            if (!unit.HasAuraById((int)CB_Executie.Auras.CSdb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CS))
                {
                    Anthrax.Logger.WriteLine("Casting - Colossus Smash");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CS, unit);
                    return;
                }
            }

            if (unit.HasAuraById((int)CB_Executie.Auras.CSdb))
            {
                if (unit.Auras.Where(x => x.SpellId == (int)CB_Executie.Auras.CSdb).First().TimeLeft <= 1000)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CS))
                    {
                        Anthrax.Logger.WriteLine("Casting - Colossus Smash");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CS, unit);
                        return;
                    }
                }
            }

            //actions.single_target+=/mortal_strike
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.MS))
            {
                Anthrax.Logger.WriteLine("Casting - Mortal Strike");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.MS, unit);
                return;
            }

            //actions.single_target+=/storm_bolt,if=enabled&debuff.colossus_smash.up
            if (unit.HasAuraById((int)CB_Executie.Auras.CSdb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SB))
                {
                    Anthrax.Logger.WriteLine("Casting - Storm Bolt");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SB, unit);
                    return;
                }
            }

            //actions.single_target+=/dragon_roar,if=enabled&debuff.colossus_smash.down
            if (!unit.HasAuraById((int)CB_Executie.Auras.CSdb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.DR))
                {
                    Anthrax.Logger.WriteLine("Casting - Dragon Roar");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.DR, unit);
                    return;
                }
            }

            //actions.single_target+=/execute,if=buff.sudden_execute.down|buff.taste_for_blood.down|rage>90|target.time_to_die<12
            if (!ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.SE) || !unit.HasAuraById((int)CB_Executie.Auras.TfB) || ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 90)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.EX))
                {
                    Anthrax.Logger.WriteLine("Casting - Execute");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.EX, unit);
                    return;
                }
            }

            //# Slam is preferable to overpower with crit procs/recklessness.
            //actions.single_target+=/slam,if=target.health.pct>=20&(trinket.stacking_stat.crit.stack>=10|buff.recklessness.up)
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.SoOCrit))
            {
                if (unit.HealthPercent > 20 && (ObjectManager.LocalPlayer.Auras.Where(x => x.SpellId == (int)CB_Executie.Auras.SoOCrit).First().StackCount >= 10))
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SL))
                    {
                        Anthrax.Logger.WriteLine("Casting - Slam");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SL, unit);
                        return;
                    }
                }
            }
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.REb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SL))
                {
                    Anthrax.Logger.WriteLine("Casting - Slam");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SL, unit);
                    return;
                }
            }

            //actions.single_target+=/overpower,if=target.health.pct>=20&rage<100|buff.sudden_execute.up
            if ((unit.HealthPercent > 20 && ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) < 100) || ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.SE))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.OP))
                {
                    Anthrax.Logger.WriteLine("Casting - Overpower");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.OP, unit);
                    return;
                }
            }

            //actions.single_target+=/execute
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.EX))
            {
                Anthrax.Logger.WriteLine("Casting - Excute");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.EX, unit);
                return;
            }

            //actions.single_target+=/slam,if=target.health.pct>=20
            if (unit.HealthPercent > 20)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SL))
                {
                    Anthrax.Logger.WriteLine("Casting - Slam");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SL, unit);
                    return;
                }
            }

            //actions.single_target+=/heroic_throw
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.HT))
            {
                Anthrax.Logger.WriteLine("Casting - Heroic Throw");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.HT, unit);
                return;
            }

            //actions.single_target+=/battle_shout
            if (Convert.ToString(CB_Executie.SMode) == "battleshout")
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BSh))
                {
                    Anthrax.Logger.WriteLine("Casting - Battle Shout");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BSh, unit);
                    return;
                }
            }

            if (Convert.ToString(CB_Executie.SMode) == "commandingshout")
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CSh))
                {
                    Anthrax.Logger.WriteLine("Casting - Commanding Shout");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CSh, unit);
                    return;
                }
            }

            //Nothing else to fire, using autottack
            Anthrax.AI.Controllers.Spell.AttackTarget();


        }
        #endregion

        #region MultitargetArms
        public void MultiTargetRotationArms(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)
        {

            // We always want to face the target
            WoW.Internals.Movements.Face(unit.Position);

            //actions.aoe=sweeping_strikes
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SS))
            {
                Anthrax.Logger.WriteLine("Casting - Sweeping Strikes");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SS, unit);
                return;
            }

            //actions.aoe+=/cleave,if=rage>110&active_enemies<=4
            if (ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 110)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CL))
                {
                    Anthrax.Logger.WriteLine("Casting - Cleave");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CL, unit);
                    return;
                }
            }

            //actions.aoe+=/bladestorm,if=enabled&(buff.bloodbath.up|!talent.bloodbath.enabled)
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.BBA))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BS))
                {
                    Anthrax.Logger.WriteLine("Casting - Bladestorm");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BS, unit);
                    return;
                }
            }

            //actions.aoe+=/dragon_roar,if=enabled&debuff.colossus_smash.down
            if (!unit.HasAuraById((int)CB_Executie.Auras.CSdb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.DR))
                {
                    Anthrax.Logger.WriteLine("Casting - Dragon Roar");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.DR, unit);
                    return;
                }
            }

            //actions.aoe+=/colossus_smash,if=debuff.colossus_smash.remains<1
            if (!unit.HasAuraById((int)CB_Executie.Auras.CSdb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CS))
                {
                    Anthrax.Logger.WriteLine("Casting - Colossus Smash 3");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CS, unit);
                    return;
                }
            }

            if (unit.HasAuraById((int)CB_Executie.Auras.CSdb))
            {
                if (unit.Auras.Where(x => x.SpellId == (int)CB_Executie.Auras.CSdb).First().TimeLeft <= 1000)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CS))
                    {
                        Anthrax.Logger.WriteLine("Casting - Colossus Smash 3");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CS, unit);
                        return;
                    }
                }
            }

            //actions.aoe+=/thunder_clap
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.TC))
            {
                Anthrax.Logger.WriteLine("Casting - Thunder Clap");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.TC, unit);
                return;
            }

            //actions.aoe+=/mortal_strike,if=active_enemies=2|rage<50
            if (ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) < 50)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.MS))
                {
                    Anthrax.Logger.WriteLine("Casting - Mortal Strike");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.MS, unit);
                    return;
                }
            }

            //actions.aoe+=/execute,if=buff.sudden_execute.down&active_enemies=2
            if (!ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.SE))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.EX))
                {
                    Anthrax.Logger.WriteLine("Casting - Excute");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.EX, unit);
                    return;
                }
            }

            //actions.aoe+=/slam,if=buff.sweeping_strikes.up&debuff.colossus_smash.up
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.SSA) && unit.HasAuraById((int)CB_Executie.Auras.CSdb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SL))
                {
                    Anthrax.Logger.WriteLine("Casting - Slam");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SL, unit);
                    return;
                }
            }

            //actions.aoe+=/overpower,if=active_enemies=2
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.OP))
            {
                Anthrax.Logger.WriteLine("Casting - Overpower");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.OP, unit);
                return;
            }

            //actions.aoe+=/slam,if=buff.sweeping_strikes.up
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.SSA))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SL))
                {
                    Anthrax.Logger.WriteLine("Casting - Slam");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SL, unit);
                    return;
                }
            }

            //actions.aoe+=/battle_shout
            if (Convert.ToString(CB_Executie.SMode) == "battleshout")
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BSh))
                {
                    Anthrax.Logger.WriteLine("Casting - Battle Shout 13");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BSh, unit);
                    return;
                }
            }

            if (Convert.ToString(CB_Executie.SMode) == "commandingshout")
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CSh))
                {
                    Anthrax.Logger.WriteLine("Casting - Commanding Shout 13");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CSh, unit);
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

        #region OnLoad
        public override void OnLoad()
        {
            CB_Executie.GetSettingsFromXML();
        }
        #endregion

        #region OnCombat
        public override void OnCombat(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)
        {

            CB_Executie.Offensives(unit);
            CB_Executie.Defensives(unit);
            if (ObjectManager.LocalPlayer.UnitsAttackingMe.Count >= CB_Executie.AOE_tars)
            {
                MultiTargetRotationArms(unit);

            }
            else
            {
                SingleTargetRotationArms(unit);

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
        #endregion

        #region Settings
        public override void Settings()
        {
            string XMLCheck = "Combats\\CB_Executie\\CB_Executie_" + CB_Executie.CharacterLoggedIn + ".xml";
            if (!File.Exists(XMLCheck))
            {
                File.Copy("Combats\\CB_Executie\\CB_Executie_default.xml", "Combats\\CB_Executie\\CB_Executie_" + CB_Executie.CharacterLoggedIn + ".xml");
                Anthrax.Logger.WriteLine("Executie - Created Settings for " + CB_Executie.CharacterLoggedIn);
            }
            else if (File.Exists(XMLCheck))
            {
                Anthrax.Logger.WriteLine("Executie - Loaded Settings for " + CB_Executie.CharacterLoggedIn);
            }
            else
            {
                Anthrax.Logger.WriteLine("Executie - Loaded Default Settings");
            }


            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "Combats\\CB_Executie\\executie_mUI.exe";
            startInfo.Arguments = CB_Executie.CharacterLoggedIn;
            Process.Start(startInfo);

        }
        #endregion

    }
    #endregion

    #region CB_Executie_Fury
    public class CB_Executie_Fury : Anthrax.Modules.ICombat
    {

        public override string Name
        {
            get { return "Executie Fury by CodingBad"; }     //This name is displayed inside Anthrax
        }

        #region OnPull
        public override void OnPull(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)
        {
            //Check if we are in BattleStance, if not, switch to
            if (ObjectManager.LocalPlayer.ShapeshiftForm != Anthrax.WoW.Classes.ObjectManager.WowUnit.WowShapeshiftForm.BattleStance &&
               Anthrax.AI.Controllers.Spell.CanUseShapeshiftForm((int)CB_Executie.Spells.BSt))
            {
                Anthrax.Logger.WriteLine("Enter Battle Stance ...");
                Anthrax.AI.Controllers.Spell.UseShapeshiftForm((int)CB_Executie.Spells.BSt);
                return;
            }

            //Charge if in range
            if (unit.Position.Distance3DFromPlayer >= 7 && unit.Position.Distance3DFromPlayer <= 28)
            {
                // No need to move anymore
                AI.Controllers.Mover.StopMoving();

                // We always want to face the target
                WoW.Internals.Movements.Face(unit.Position);

                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CH))
                {
                    Anthrax.Logger.WriteLine("Pull - Charge");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CH, unit);
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

        #region SingletargetFury
        public void SingleTargetRotationFury(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)
        {
            //We always want to face the target
            WoW.Internals.Movements.Face(unit.Position);

            //actions.single_target+=/heroic_strike,if=((debuff.colossus_smash.up&rage>=40)&target.health.pct>=20)|rage>=100&buff.enrage.up
            if ((ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.EnR) && ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 100) || (unit.HasAuraById((int)CB_Executie.Auras.CSdb) && ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 40))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.HS))
                {
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.HS, unit);
                    Anthrax.Logger.WriteLine("Casting - Heroic Strike");
                    return;
                }
            }

            //# Galakras cooldown reduction trinket allows Storm Bolt to be synced with Colossus Smash. 
            //actions.single_target+=/storm_bolt,if=enabled&buff.cooldown_reduction.up&debuff.colossus_smash.up
            if (CB_Executie.CD_Reduction_Trinket())
            {
                if (unit.HasAuraById((int)CB_Executie.Auras.CSdb))
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SB))
                    {
                        Anthrax.Logger.WriteLine("Casting - Storm Bolt CD REDUCE TRUE");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SB, unit);
                        return;
                    }
                }
            }

            //# Delay Bloodthirst if 2 stacks of raging blow are available inside Colossus Smash.
            //actions.single_target+=/raging_blow,if=buff.raging_blow.stack=2&debuff.colossus_smash.up&target.health.pct>=20
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.RBA))
            {
                if (ObjectManager.LocalPlayer.Auras.Where(x => x.SpellId == (int)CB_Executie.Auras.RBA).First().StackCount == 2 && unit.HasAuraById((int)CB_Executie.Auras.CSdb) && unit.HealthPercent >= 20)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.RB))
                    {
                        Anthrax.Logger.WriteLine("Casting - Raging Blow");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.RB, unit);
                        return;
                    }
                }
            }

            //actions.single_target+=/storm_bolt,if=enabled&buff.cooldown_reduction.down&debuff.colossus_smash.up
            if (!CB_Executie.CD_Reduction_Trinket())
            {
                if (unit.HasAuraById((int)CB_Executie.Auras.CSdb))
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SB))
                    {
                        Anthrax.Logger.WriteLine("Casting - Storm Bolt CD REDUCE FALSE");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SB, unit);
                        return;
                    }
                }
            }

            //# Until execute range, Bloodthirst is used on cooldown 95% of the time. When execute range is reached, bloodthirst can be delayed 1-2~ globals as long as the conditions below are met.
            //# This is done to lower the amount of heroic strike usage, and to increase the amount of executes used.
            //actions.single_target+=/bloodthirst,if=!(target.health.pct<20&debuff.colossus_smash.up&rage>=30&buff.enrage.up)
            if (!(unit.HealthPercent < 20 && unit.HasAuraById((int)CB_Executie.Auras.CSdb) && ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) >= 30 && ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.EnR)))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BT))
                {
                    Anthrax.Logger.WriteLine("Casting - Bloodthirst");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BT, unit);
                    return;
                }
            }

            //# The GCD reduction of the Bloodsurge buff allows 3 Wild Strikes in-between Bloodthirst.
            //actions.single_target+=/wild_strike,if=buff.bloodsurge.react&target.health.pct>=20&cooldown.bloodthirst.remains<=1
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.BSuA))
            {
                if (unit.HealthPercent >= 20)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.WS))
                    {
                        Anthrax.Logger.WriteLine("Casting - Wild Strike");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.WS, unit);
                        return;
                    }
                }
            }

            //actions.single_target+=/wait,sec=cooldown.bloodthirst.remains,if=!(target.health.pct<20&debuff.colossus_smash.up&rage>=30&buff.enrage.up)&cooldown.bloodthirst.remains<=1


            //actions.single_target+=/dragon_roar,if=enabled&(!debuff.colossus_smash.up&(buff.bloodbath.up|!talent.bloodbath.enabled))
            if (!unit.HasAuraById((int)CB_Executie.Auras.CSdb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.DR))
                {
                    Anthrax.Logger.WriteLine("Casting - Dragon Roar");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.DR, unit);
                    return;
                }
            }

            //# The debuff from Colossus Smash lasts 6.5 seconds and also has 0.25~ seconds of travel time. This allows 4 1.5 second globals to be used inside of it every time now.
            //actions.single_target+=/colossus_smash            
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CS))
            {
                Anthrax.Logger.WriteLine("Casting - Colossus Smash");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CS, unit);
                return;
            }


            //actions.single_target+=/storm_bolt,if=enabled&buff.cooldown_reduction.down
            if (!CB_Executie.CD_Reduction_Trinket())
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SB))
                {
                    Anthrax.Logger.WriteLine("Casting - Storm Bolt 2 CD REDUCE FALSE");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SB, unit);
                    return;
                }
            }

            //actions.single_target+=/execute,if=debuff.colossus_smash.up|rage>70|target.time_to_die<12
            if (unit.HasAuraById((int)CB_Executie.Auras.CSdb) || ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 70)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.EX))
                {
                    Anthrax.Logger.WriteLine("Casting - Execute");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.EX, unit);
                    return;
                }
            }

            //actions.single_target+=/raging_blow,if=target.health.pct<20|buff.raging_blow.stack=2|(debuff.colossus_smash.up|(cooldown.bloodthirst.remains>=1&buff.raging_blow.remains<=3))
            if (unit.HealthPercent < 20)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.RB))
                {
                    Anthrax.Logger.WriteLine("Casting - Raging Blow");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.RB, unit);
                    return;
                }
            }

            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.RBA))
            {
                if (ObjectManager.LocalPlayer.Auras.Where(x => x.SpellId == (int)CB_Executie.Auras.RBA).First().StackCount == 2)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.RB))
                    {
                        Anthrax.Logger.WriteLine("Casting - Raging Blow");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.RB, unit);
                        return;
                    }
                }
            }

            if (unit.HasAuraById((int)CB_Executie.Auras.CSdb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.RB))
                {
                    Anthrax.Logger.WriteLine("Casting - Raging Blow");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.RB, unit);
                    return;
                }
            }

            //actions.single_target+=/bladestorm,if=enabled


            //actions.single_target+=/wild_strike,if=buff.bloodsurge.up
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.BSuA))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.WS))
                {
                    Anthrax.Logger.WriteLine("Casting - Wild Strike");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.WS, unit);
                    return;
                }
            }

            //# If Colossus Smash is coming up soon, it's a good idea to save 1 charge of raging blow for it.
            //actions.single_target+=/raging_blow,if=cooldown.colossus_smash.remains>=3


            //# Shattering Throw is a very small personal dps increase, but a fairly significant raid dps increase. Only use to fill empty globals.
            //actions.single_target+=/shattering_throw,if=cooldown.colossus_smash.remains>5


            //actions.single_target+=/shockwave,if=enabled


            //actions.single_target+=/heroic_throw,if=debuff.colossus_smash.down&rage<60
            if (!unit.HasAuraById((int)CB_Executie.Auras.CSdb) && ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) < 60)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.HT))
                {
                    Anthrax.Logger.WriteLine("Casting - Heroic Throw");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.HT, unit);
                    return;
                }
            }

            //actions.single_target+=/battle_shout,if=rage<70&!debuff.colossus_smash.up
            if (!unit.HasAuraById((int)CB_Executie.Auras.CSdb) && ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) < 70)
            {
                if (Convert.ToString(CB_Executie.SMode) == "battleshout")
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BSh))
                    {
                        Anthrax.Logger.WriteLine("Casting - Battle Shout");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BSh, unit);
                        return;
                    }
                }

                if (Convert.ToString(CB_Executie.SMode) == "commandingshout")
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CSh))
                    {
                        Anthrax.Logger.WriteLine("Casting - Commanding Shout");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CSh, unit);
                        return;
                    }
                }
            }

            //actions.single_target+=/wild_strike,if=debuff.colossus_smash.up&target.health.pct>=20
            if (unit.HasAuraById((int)CB_Executie.Auras.CSdb) && unit.HealthPercent >= 20)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.WS))
                {
                    Anthrax.Logger.WriteLine("Casting - Wild Strike");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.WS, unit);
                    return;
                }
            }

            //actions.single_target+=/battle_shout,if=rage<70
            if (ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) < 70)
            {
                if (Convert.ToString(CB_Executie.SMode) == "battleshout")
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BSh))
                    {
                        Anthrax.Logger.WriteLine("Casting - Battle Shout");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BSh, unit);
                        return;
                    }
                }

                if (Convert.ToString(CB_Executie.SMode) == "commandingshout")
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CSh))
                    {
                        Anthrax.Logger.WriteLine("Casting - Commanding Shout");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CSh, unit);
                        return;
                    }
                }
            }

            //actions.single_target+=/wild_strike,if=cooldown.colossus_smash.remains>=2&rage>=70&target.health.pct>=20
            //if (unit.HasAuraById((int)CB_Executie.Auras.CSdb) && unit.HealthPercent >= 20)
            //{
            //    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.WS))
            //    {
            //        Anthrax.Logger.WriteLine("Casting - Wild Strike");
            //        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.WS, unit);
            //        return;
            //    }
            //}

            //actions.single_target+=/impending_victory,if=enabled&target.health.pct>=20&cooldown.colossus_smash.remains>=2




            //Nothing else to fire, using autottack
            Anthrax.AI.Controllers.Spell.AttackTarget();


        }
        #endregion

        #region TwoTargetFury
        public void TwoTargetRotationFury(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)
        {
            //actions.two_targets=bloodbath,if=enabled&((!talent.bladestorm.enabled&(cooldown.colossus_smash.remains<2|debuff.colossus_smash.remains>=5|target.time_to_die<=20))|(talent.bladestorm.enabled))
            if (unit.HasAuraById((int)CB_Executie.Auras.CSdb))
            {
                if (unit.Auras.Where(x => x.SpellId == (int)CB_Executie.Auras.CSdb).First().TimeLeft > 4000)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BB))
                    {
                        Anthrax.Logger.WriteLine("Casting - Blood Bath");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BB, ObjectManager.LocalPlayer);
                    }
                }
            }

            //actions.two_targets+=/cleave,if=(rage>=60&debuff.colossus_smash.up)|rage>110
            if ((ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) >= 60 && unit.HasAuraById((int)CB_Executie.Auras.CSdb)) || ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 110)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CL))
                {
                    Anthrax.Logger.WriteLine("Casting - Cleave");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CL, unit);
                    return;
                }
            }

            //actions.two_targets+=/heroic_leap,if=buff.enrage.up&(debuff.colossus_smash.up&buff.cooldown_reduction.up|!buff.cooldown_reduction.up)

            //actions.two_targets+=/bladestorm,if=enabled&(buff.bloodbath.up|!talent.bloodbath.enabled)&(!talent.storm_bolt.enabled|(talent.storm_bolt.enabled&!debuff.colossus_smash.up))
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.BBA))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BS))
                {
                    Anthrax.Logger.WriteLine("Casting - Bladestorm");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BS, unit);
                    return;
                }
            }

            //# Generally, if an encounter has any type of AoE, Bladestorm will be the better choice than Dragon Roar.
            //actions.two_targets+=/dragon_roar,if=enabled&(!debuff.colossus_smash.up&(buff.bloodbath.up|!talent.bloodbath.enabled))
            if (!unit.HasAuraById((int)CB_Executie.Auras.CSdb) && ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.BBA))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.DR))
                {
                    Anthrax.Logger.WriteLine("Casting - Dragon Roar");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.DR, unit);
                    return;
                }
            }
            //actions.two_targets+=/colossus_smash
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CS))
            {
                Anthrax.Logger.WriteLine("Casting - Colossus Smash");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CS, unit);
                return;
            }

            //actions.two_targets+=/storm_bolt,if=enabled&debuff.colossus_smash.up
            if (unit.HasAuraById((int)CB_Executie.Auras.CSdb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SB))
                {
                    Anthrax.Logger.WriteLine("Casting - Storm Bolt");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SB, unit);
                    return;
                }
            }

            //actions.two_targets+=/bloodthirst
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BT))
            {
                Anthrax.Logger.WriteLine("Casting - Bloodthirst");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BT, unit);
                return;
            }

            //actions.two_targets+=/wait,sec=cooldown.bloodthirst.remains,if=!(target.health.pct<20&debuff.colossus_smash.up&rage>=30&buff.enrage.up)&cooldown.bloodthirst.remains<=1

            //actions.two_targets+=/raging_blow,if=buff.meat_cleaver.up
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.MCA))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.RB))
                {
                    Anthrax.Logger.WriteLine("Casting - Raging Blow");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.RB, unit);
                    return;
                }
            }
            //actions.two_targets+=/whirlwind,if=!buff.meat_cleaver.up
            if (!ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.MCA))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.WW))
                {
                    Anthrax.Logger.WriteLine("Casting - Whirlwind");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.WW, unit);
                    return;
                }
            }

            //actions.two_targets+=/execute
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.EX))
            {
                Anthrax.Logger.WriteLine("Casting - Excute");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.EX, unit);
                return;
            }

            //actions.two_targets+=/battle_shout
            if (Convert.ToString(CB_Executie.SMode) == "battleshout")
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BSh))
                {
                    Anthrax.Logger.WriteLine("Casting - Battle Shout 13");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BSh, unit);
                    return;
                }
            }

            if (Convert.ToString(CB_Executie.SMode) == "commandingshout")
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CSh))
                {
                    Anthrax.Logger.WriteLine("Casting - Commanding Shout 13");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CSh, unit);
                    return;
                }
            }
            //actions.two_targets+=/heroic_throw
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.HT))
            {
                Anthrax.Logger.WriteLine("Casting - Heroic Throw");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.HT, unit);
                return;
            }
        }
        #endregion

        #region ThreeTargetRotationFury
        public void ThreeTargetRotationFury(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)
        {
            //actions.three_targets=bloodbath,if=enabled
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BB))
            {
                Anthrax.Logger.WriteLine("Casting - Blood Bath");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BB, ObjectManager.LocalPlayer);
            }

            //actions.three_targets+=/cleave,if=(rage>=70&debuff.colossus_smash.up)|rage>90
            if ((ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) >= 70 && unit.HasAuraById((int)CB_Executie.Auras.CSdb)) || ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 90)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CL))
                {
                    Anthrax.Logger.WriteLine("Casting - Cleave");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CL, unit);
                    return;
                }
            }
            //actions.three_targets+=/heroic_leap,if=buff.enrage.up&(debuff.colossus_smash.up&buff.cooldown_reduction.up|!buff.cooldown_reduction.up)

            //actions.three_targets+=/bladestorm,if=enabled&(buff.bloodbath.up|!talent.bloodbath.enabled)
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.BBA))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BS))
                {
                    Anthrax.Logger.WriteLine("Casting - Bladestorm");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BS, unit);
                    return;
                }
            }

            //actions.three_targets+=/bloodthirst,if=buff.enrage.down
            if (!ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.EnR))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BT))
                {
                    Anthrax.Logger.WriteLine("Casting - Bloodthirst");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BT, unit);
                    return;
                }
            }

            //actions.three_targets+=/dragon_roar,if=enabled&!debuff.colossus_smash.up&(buff.bloodbath.up|!talent.bloodbath.enabled)
            if (!unit.HasAuraById((int)CB_Executie.Auras.CSdb) && ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.BBA))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.DR))
                {
                    Anthrax.Logger.WriteLine("Casting - Dragon Roar");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.DR, unit);
                    return;
                }
            }

            //actions.three_targets+=/colossus_smash
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CS))
            {
                Anthrax.Logger.WriteLine("Casting - Colossus Smash");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CS, unit);
                return;
            }

            //actions.three_targets+=/storm_bolt,if=enabled&debuff.colossus_smash.up
            if (unit.HasAuraById((int)CB_Executie.Auras.CSdb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SB))
                {
                    Anthrax.Logger.WriteLine("Casting - Storm Bolt");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SB, unit);
                    return;
                }
            }

            //actions.three_targets+=/raging_blow,if=buff.meat_cleaver.stack=2
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.MCA))
            {
                if (ObjectManager.LocalPlayer.Auras.Where(x => x.SpellId == (int)CB_Executie.Auras.MCA).First().StackCount == 2)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.RB))
                    {
                        Anthrax.Logger.WriteLine("Casting - Raging Blow");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.RB, unit);
                        return;
                    }
                }
            }
            //actions.three_targets+=/whirlwind
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.WW))
            {
                Anthrax.Logger.WriteLine("Casting - Whirlwind");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.WW, unit);
                return;
            }

            //actions.three_targets+=/raging_blow
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.RB))
            {
                Anthrax.Logger.WriteLine("Casting - Raging Blow");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.RB, unit);
                return;
            }

            //actions.three_targets+=/battle_shout
            if (Convert.ToString(CB_Executie.SMode) == "battleshout")
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BSh))
                {
                    Anthrax.Logger.WriteLine("Casting - Battle Shout 13");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BSh, unit);
                    return;
                }
            }

            if (Convert.ToString(CB_Executie.SMode) == "commandingshout")
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CSh))
                {
                    Anthrax.Logger.WriteLine("Casting - Commanding Shout 13");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CSh, unit);
                    return;
                }
            }

            //actions.three_targets+=/heroic_throw            
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.HT))
            {
                Anthrax.Logger.WriteLine("Casting - Heroic Throw");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.HT, unit);
                return;
            }
        }
        #endregion

        #region MultiTargetRotationFury
        public void MultiTargetRotationFury(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)
        {
            //actions.aoe=bloodbath,if=enabled
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BB))
            {
                Anthrax.Logger.WriteLine("Casting - Blood Bath");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BB, ObjectManager.LocalPlayer);
            }

            //actions.aoe+=/cleave,if=rage>90
            if ((ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 90))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CL))
                {
                    Anthrax.Logger.WriteLine("Casting - Cleave");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CL, unit);
                    return;
                }
            }
            //actions.aoe+=/heroic_leap,if=buff.enrage.up

            //actions.aoe+=/bladestorm,if=enabled&(buff.bloodbath.up|!talent.bloodbath.enabled)
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.BBA))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BS))
                {
                    Anthrax.Logger.WriteLine("Casting - Bladestorm");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BS, unit);
                    return;
                }
            }

            //actions.aoe+=/bloodthirst,if=buff.enrage.down
            if (!ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.EnR))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BT))
                {
                    Anthrax.Logger.WriteLine("Casting - Bloodthirst");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BT, unit);
                    return;
                }
            }
            //actions.aoe+=/raging_blow,if=buff.meat_cleaver.stack=3
            if (ObjectManager.LocalPlayer.HasAuraById((int)CB_Executie.Auras.MCA))
            {
                if (ObjectManager.LocalPlayer.Auras.Where(x => x.SpellId == (int)CB_Executie.Auras.MCA).First().StackCount == 3)
                {
                    if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.RB))
                    {
                        Anthrax.Logger.WriteLine("Casting - Raging Blow");
                        Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.RB, unit);
                        return;
                    }
                }
            }

            //actions.aoe+=/whirlwind
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.WW))
            {
                Anthrax.Logger.WriteLine("Casting - Whirlwind");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.WW, unit);
                return;
            }

            //# Dragon roar is a poor choice on large-scale AoE as the damage it does is reduced with additional targets. The damage it does per target is reduced by the following amounts:
            //# 1/2/3/4/5+ targets ---> 0%/25%/35%/45%/50%
            //actions.aoe+=/dragon_roar,if=enabled&debuff.colossus_smash.down&(buff.bloodbath.up|!talent.bloodbath.enabled)

            //actions.aoe+=/bloodthirst,cycle_targets=1,if=!dot.deep_wounds.ticking
            if (!unit.HasAuraById((int)CB_Executie.Auras.DWdb))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BT))
                {
                    Anthrax.Logger.WriteLine("Casting - Bloodthirst");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BT, unit);
                    return;
                }
            }
            //actions.aoe+=/colossus_smash
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CS))
            {
                Anthrax.Logger.WriteLine("Casting - Colossus Smash");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CS, unit);
                return;
            }

            //actions.aoe+=/storm_bolt,if=enabled
            if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.SB))
            {
                Anthrax.Logger.WriteLine("Casting - Storm Bolt");
                Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.SB, unit);
                return;
            }

            //actions.aoe+=/battle_shout
            if (Convert.ToString(CB_Executie.SMode) == "battleshout")
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.BSh))
                {
                    Anthrax.Logger.WriteLine("Casting - Battle Shout 13");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.BSh, unit);
                    return;
                }
            }

            if (Convert.ToString(CB_Executie.SMode) == "commandingshout")
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)CB_Executie.Spells.CSh))
                {
                    Anthrax.Logger.WriteLine("Casting - Commanding Shout 13");
                    Anthrax.AI.Controllers.Spell.Cast((int)CB_Executie.Spells.CSh, unit);
                    return;
                }
            }
        }
        #endregion

        #region OnLoad
        public override void OnLoad()
        {
            CB_Executie.GetSettingsFromXML();
        }
        #endregion

        #region OnCombat
        public override void OnCombat(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)
        {
            CB_Executie.Offensives(unit);
            CB_Executie.Defensives(unit);

            if (ObjectManager.LocalPlayer.UnitsAttackingMe.Count >= 4)
            {
                MultiTargetRotationFury(unit);
            }
            else if (ObjectManager.LocalPlayer.UnitsAttackingMe.Count == 3)
            {
                ThreeTargetRotationFury(unit);
            }
            else if (ObjectManager.LocalPlayer.UnitsAttackingMe.Count == 2)
            {
                TwoTargetRotationFury(unit);
            }
            else
            {
                SingleTargetRotationFury(unit);

            }

        }
        #endregion

        #region Settings
        public override void Settings()
        {
            string XMLCheck = "Combats\\CB_Executie\\CB_Executie_" + CB_Executie.CharacterLoggedIn + ".xml";
            if (!File.Exists(XMLCheck))
            {
                File.Copy("Combats\\CB_Executie\\CB_Executie_default.xml", "Combats\\CB_Executie\\CB_Executie_" + CB_Executie.CharacterLoggedIn + ".xml");
                Anthrax.Logger.WriteLine("Executie - Created Settings for " + CB_Executie.CharacterLoggedIn);
            }
            else if (File.Exists(XMLCheck))
            {
                Anthrax.Logger.WriteLine("Executie - Loaded Settings for " + CB_Executie.CharacterLoggedIn);
            }
            else
            {
                Anthrax.Logger.WriteLine("Executie - Loaded Default Settings");
            }


            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "Combats\\CB_Executie\\executie_mUI.exe";
            startInfo.Arguments = CB_Executie.CharacterLoggedIn;
            Process.Start(startInfo);

        }
        #endregion

    }
    #endregion

}


