using System;
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
//


namespace Anthrax
{
    public class Executie_Arms : Anthrax.Modules.ICombat  //This file must be copied inside the CombatClass folder
    {

        

        #region private vars
        private System.Timers.Timer wndCloser = new System.Timers.Timer(2000);
        bool isAOE;
        Anthrax.WoW.Classes.ObjectManager.WowLocalPlayer ME;
        #endregion

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        #region importSettings
        int RC_HP, SW_HP, DbtS_HP, DBa_HP, ER_HP, DSt_HP;
        bool DStuse;
        public void GetSettingsFromXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\Coding\\Anthrax\\Combats\\exeCutie.xml");

            RC_HP = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/General/RallyingCry").InnerText);
            SW_HP = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/General/ShieldWall").InnerText);
            DbtS_HP = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/General/DieByTheSword").InnerText);
            DBa_HP = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/General/DemoBanner").InnerText);
            ER_HP = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/General/EnragedRegeneration").InnerText);
            DStuse = Convert.ToBoolean(doc.SelectSingleNode("ExecutieSettings/General/DStuse").InnerText);
            DSt_HP = Convert.ToInt32(doc.SelectSingleNode("ExecutieSettings/General/DStHP").InnerText);
            

            Anthrax.Logger.WriteLine("RallyingCry at: " + RC_HP);
            Anthrax.Logger.WriteLine("ShieldWall at: " + SW_HP);
            Anthrax.Logger.WriteLine("Die by the Sword at: " + DbtS_HP);
            Anthrax.Logger.WriteLine("Demo Banner at: " + DBa_HP);
            Anthrax.Logger.WriteLine("Enraged Regeneration at: " + ER_HP);
            Anthrax.Logger.WriteLine("Use DefStance : " + DStuse);
            Anthrax.Logger.WriteLine("DefStanc at: " + DSt_HP);
            Console.Read();  
        }        
        #endregion

        #region enums
        public enum Spells : int
        {
            AV = 107574,            //Avatar
            BB = 12292,             //Blood Bath
            BF = 20572,             //Blood Fury (Orc)
            BR = 18499,             //Berserker Rage
            BS = 46924,             //Blade Storm
            BSh = 6673,             //Battle Shout
            BSt = 2457,             //Battle Stance
            CH = 100,               //Charge
            CL = 845,               //Cleave
            CS = 86346,             //Colossus Smash
            CSh = 69,               //Commanding Shout
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
            BShA = 6673,            //Battle Shout Aura
            CSdb = 86346,           //CSmash Debuff
            CShA = 69,              //Commanding Shout Aura
            DS = 144442,            //Death Sentence
            EnR = 12880,            //Enrage
            SE = 139958,            //Sudden Execute
            T162P = 144438,         //T16 2 Piece Bonus
            TfB = 56636,            //Taste for Blood
            DWdb = 115767,          //Deep Wounds Debuff
            SoOCrit = 146285,       //Crit Proc of Skeers Trinket, Stacking to 20
            REb = 1719,             //Recklessness

            BLust = 2825,           //Bloodlust
            HRoism = 32182,         //Heroism
            TWarp = 80353,          //Timewarp
            AHysteria = 90355,      //Ancient Hysteria
            NWinds = 160452,        //Netherwinds
        }
        
        public enum Items : int
        {
            MoguPot = 76095,        //Potion of Mogu Power
        }
        #endregion

        #region BloodlustCheck
        //Check for Bloodlust
        private bool hasLust()
        {
            if (ObjectManager.LocalPlayer.HasAuraById((int)Auras.BLust) ||ME.HasAuraById((int)Auras.HRoism) ||ME.HasAuraById((int)Auras.TWarp) ||ME.HasAuraById((int)Auras.AHysteria) ||ME.HasAuraById((int)Auras.NWinds))
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
            get { return "Executie Arms"; }     //This name is displayed inside Anthrax
        }

        #region OnPull
        public override void OnPull(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)             
        {
            //Check if we are in BattleStance, if not, switch to
            if (Anthrax.WoW.Internals.ObjectManager.LocalPlayer.ShapeshiftForm != Anthrax.WoW.Classes.ObjectManager.WowUnit.WowShapeshiftForm.BattleStance &&
               Anthrax.AI.Controllers.Spell.CanUseShapeshiftForm((int)Spells.BSt))
            {
                Anthrax.Logger.WriteLine("Enter Battle Stance ...");
                Anthrax.AI.Controllers.Spell.UseShapeshiftForm((int)Spells.BSt);
                return;
            }
            
            //Charge if in range
            if (unit.Position.Distance3DFromPlayer >= 7 && unit.Position.Distance3DFromPlayer <= 28)                                         
            {
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

        #region OnCombat
        public override void OnCombat(Anthrax.WoW.Classes.ObjectManager.WowUnit unit)     
        {
            #region aliases
            float myRage = ME.GetPowerPercent(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage);
            float myHealth = ME.HealthPercent;
            #endregion

            //Battle / Defensive Stance
            if (ObjectManager.LocalPlayer.HealthPercent <= 30)
            {
                if (Anthrax.WoW.Internals.ObjectManager.LocalPlayer.ShapeshiftForm != Anthrax.WoW.Classes.ObjectManager.WowUnit.WowShapeshiftForm.DefensiveStance && Anthrax.AI.Controllers.Spell.CanUseShapeshiftForm((int)Spells.DSt))
                {
                    Anthrax.Logger.WriteLine("Enter Defensive Stance ...");
                    Anthrax.AI.Controllers.Spell.UseShapeshiftForm((int)Spells.DSt);
                    return;
                }  
            }
            else
            {
                if (Anthrax.WoW.Internals.ObjectManager.LocalPlayer.ShapeshiftForm != Anthrax.WoW.Classes.ObjectManager.WowUnit.WowShapeshiftForm.BattleStance && Anthrax.AI.Controllers.Spell.CanUseShapeshiftForm((int)Spells.BSt))
                {
                    Anthrax.Logger.WriteLine("Enter Battle Stance ...");
                    Anthrax.AI.Controllers.Spell.UseShapeshiftForm((int)Spells.BSt);
                    return;
                }
                           
            }

            //actions+=/mogu_power_potion,if=(target.health.pct<20&buff.recklessness.up)|buff.bloodlust.react|target.time_to_die<=25
            if ((unit.HealthPercent < 20 && ME.HasAuraById((int)Auras.REb)) || hasLust())
            {
                Anthrax.Logger.WriteLine("Using Mogu Potion");
                Anthrax.AI.Controllers.Inventory.UseItemById((int)Items.MoguPot);
            }            

            //actions.single_target=heroic_strike,if=rage>115|(debuff.colossus_smash.up&rage>60&set_bonus.tier16_2pc_melee)
            if (ObjectManager.LocalPlayer.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 115 || (unit.HasAuraById((int)Auras.CSdb) && ME.HasAuraById((int)Auras.T162P)))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.HS))
                {
                    Anthrax.Logger.WriteLine("Casting - Heroic Strike");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.HS, unit);
                    return;
                }
            }

            //actions.single_target+=/mortal_strike,if=dot.deep_wounds.remains<1.0|buff.enrage.down|rage<10            
            if (unit.Auras.Where(x => x.SpellId == (int)Auras.DWdb).First().TimeLeft <= 1000 || !ObjectManager.LocalPlayer.HasAuraById((int)Auras.EnR) || ME.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) < 10)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.MS))
                {
                    Anthrax.Logger.WriteLine("Casting - Mortal Strike - " + myRage + " Rage now - " + myHealth + "prc HP");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.MS, unit);
                    return;
                }
            }

            //actions.single_target+=/colossus_smash,if=debuff.colossus_smash.remains<1.0
            if (unit.Auras.Where(x => x.SpellId == (int)Auras.CSdb).First().TimeLeft <= 1000)
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.CS))
                {
                    Anthrax.Logger.WriteLine("Casting - Colossus Smash");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.CS, unit);
                    return;
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
            if (!unit.HasAuraById((int)Auras.SE) || !unit.HasAuraById((int)Auras.TfB) || ME.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) > 90)
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
            if (unit.HealthPercent > 20 && (unit.Auras.Where(x => x.SpellId == (int)Auras.SoOCrit).First().StackCount >= 10 || ME.HasAuraById((int)Auras.REb)))
            {
                if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.SL))
                {
                    Anthrax.Logger.WriteLine("Casting - Slam");
                    Anthrax.AI.Controllers.Spell.Cast((int)Spells.SL, unit);
                    return;
                }
            }
            
            //actions.single_target+=/overpower,if=target.health.pct>=20&rage<100|buff.sudden_execute.up
            if (unit.HealthPercent > 20 && ME.GetPower(Anthrax.WoW.Classes.ObjectManager.WowUnit.WowPowerType.Rage) < 100 || ME.HasAuraById((int)Auras.SE))
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
            if (Anthrax.AI.Controllers.Spell.CanCast((int)Spells.BSh))
            {
                Anthrax.Logger.WriteLine("Casting - Battle Shout");
                Anthrax.AI.Controllers.Spell.Cast((int)Spells.BSh, unit);
                return;
            }



            //Nothing else to fire, using autottack
            Anthrax.AI.Controllers.Spell.AttackTarget();
            
        }
        #endregion

        public override void Settings()
        {
            Anthrax.Logger.WriteLine("Settings clicked");
            GetSettingsFromXML();
            Process.Start("D:\\Coding\\Anthrax\\Combats\\exeCutie.exe");
        }

        

        

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