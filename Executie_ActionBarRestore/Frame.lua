--------------------------------------------------------------------------------------/
----                                                                                 --
----                   ##################                                            --
----                   #                #                                            --
----                   #    ___         #     _   _                                  --
----                   #   / __|  ___   #  __| | (_)  _ _    __ _                    -- 
----                   #  | (__  / _ \  # / _` | | | | ' \  / _` |                   --
----                   #   \___| \___/  # \__,_| |_| |_||_| \__, |                   -- 
----                   #                #                   |___/                    --  
----                   #                #                                            --
----                   ###################################                           --
----                                    #                #                           --
----                                    #      ___       #            _              --
----                                    #     | _ )      #  __ _   __| |             --
----                                    #     | _ \      # / _` | / _` |             --
----                                    #     |___/      # \__,_| \__,_|             --
----                                    #                #                           --
----                                    #                #                           --
----                                    ##################                           --
----                                                                                 --
--------------------------------------------------------------------------------------/

function MainFrame_OnLoad()
	--MainFrame:Hide();
	SlashCmdList["Executie"] = MainFrame:Show();
	SLASH_EXECUTIE1= "/executie";
end

function MainFrame_OnEvent()
	--[[if (event == "PLAYER_TARGET_CHANGED") then
		FontString1:SetText("Hello " .. UnitName("target") .. "!")
	end]]--
end

function clearBars()
	local i = 1
	while i  <= 72 do
		PickupAction(i);
		ClearCursor();
		i = i + 1
	end
end

function ButtonClose_OnClick()
	MainFrame:Hide();
end

function ButtonArms_OnClick()
	clearBars();
	putArmsSpellsOnBars();
end

function ButtonFury_OnClick()
	print("Fury");
end




function putArmsSpellsOnBars()
	local i = 1
	local spell_list = {
    107574,            --Avatar
    12292,             --Blood Bath
    20572,             --Blood Fury (Orc)
    18499,             --Berserker Rage
    46924,             --Blade Storm
    6673,              --Battle Shout
    --2457,            --Battle Stance
    100,               --Charge
    845,               --Cleave
    86346,             --Colossus Smash
    69,                --Commanding Shout
    --676,             --Disarm
    14203,             --Demoralizing Banner
    118038,            --Die by the Sword
    118000,            --Dragon Roar
    102060,            --Disrupting Shout
    --71,              --Defensive Stance 7376
    12880,             --Enrage
    55694,             --Enraged Regeneration
    5308,              --Execute
    1715,              --Harmstring
    6544,              --Heroic Leap
    78,                --Heroic Strike
    57755,             --Heroic Throw
    5246,              --Intimidating Shout
    3411,              --Intervene
    103840,            --Impending Victory
    12294,             --Mortal Strike
    7384,              --Overpower
    6552,              --Pummel
    97462,             --Rallying Cry
    1719,              --Recklessness
    107570,            --Storm Bold
    114207,            --Skull Banner
    114029,            --Safeguard
    1464,              --Slam
    --23920,           --Spell Reflection
    12328,             --Sweeping Strikes
    64382,             --Shattering Throw
    871,               --Shield Wall
    46968,             --Shockwave
    6343,              --Thunder Clap
    114030,            --Vigilance
    34428,             --Victory Rush  
    --1680,              --Whirlwind
  	}
	for spellcount = 1,#spell_list do
		PickupSpell(spell_list[spellcount]);
		PlaceAction(i);
		ClearCursor();
		i = i + 1
	end
end