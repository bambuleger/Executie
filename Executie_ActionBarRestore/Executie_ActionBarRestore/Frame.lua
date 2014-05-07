-------------------------------------------------------------------------------------
--                                                                                 --
--                   ##################                                            --
--                   #                #                                            --
--                   #    ___         #     _   _                                  --
--                   #   / __|  ___   #  __| | (_)  _ _    __ _                    -- 
--                   #  | (__  / _ \  # / _` | | | | ' \  / _` |                   --
--                   #   \___| \___/  # \__,_| |_| |_||_| \__, |                   -- 
--                   #                #                   |___/                    --  
--                   #                #                                            --
--                   ###################################                           --
--                                    #                #                           --
--                                    #      ___       #            _              --
--                                    #     | _ )      #  __ _   __| |             --
--                                    #     | _ \      # / _` | / _` |             --
--                                    #     |___/      # \__,_| \__,_|             --
--                                    #                #                           --
--                                    #                #                           --
--                                    ##################                           --
--                                                                                 --
-------------------------------------------------------------------------------------

	SLASH_CUTIEREST1 = "/cutierest"
	SlashCmdList["CUTIEREST"] = function(msg)
    local command, args = strsplit(" ", strtrim(msg), 2) -- trim leading/trailing spaces before splitting
 
    if command == "show" then
        CutieRestMainFrame:Hide()
        CutieRestMainFrame:Show()
    elseif command == "hide" then
        CutieRestMainFrame:Hide()
    elseif command == "toggle" then
        CutieRestMainFrame:SetShown(not CutieRestMainFrame:IsShown())
	else
        print("|cffffc000Executie ActionBarRestore:|r Use /cutierest with the following commands:")
        print("   show - Show Addon")
        print("   hide - Hide Addon")
        print("   toggle - Toggle Addon")
		print("If you encounter any problems using this addon, please report in our support thread.")
    end
end


--MainFrame
function CutieRestMainFrame_OnLoad()

end

function CutieRestMainFrame_OnEvent()
	--[[if (event == "PLAYER_TARGET_CHANGED") then
		FontString1:SetText("Hello " .. UnitName("target") .. "!")
	end]]--
end

function CutieRestArmsConfirmFrame_OnLoad()

end

function CutieRestFuryConfirmFrame_OnLoad()

end

--Buttons
function CutieRestButtonClose_OnClick()
	CutieRestMainFrame:Hide()
end

function CutieRestButtonArms_OnClick()
	CutieRestArmsConfirmFrame:Show()
end

function CutieRestButtonFury_OnClick()
    CutieRestFuryConfirmFrame:Show()
end

function CutieRestArmsConfirmOkButton_OnClick()
    CutieRestclearBars()
    CutieRestputArmsSpellsOnBars()
    CutieRestArmsConfirmFrame:Hide()
end

function CutieRestArmsConfirmCancelButton_OnClick()
    CutieRestArmsConfirmFrame:Hide()
end

function CutieRestFuryConfirmOkButton_OnClick()
    CutieRestclearBars()
    CutieRestputFurySpellsOnBars()
    CutieRestFuryConfirmFrame:Hide()
end

function CutieRestFuryConfirmCancelButton_OnClick()
    CutieRestFuryConfirmFrame:Hide()
end

--Kaboom Baby! Wipe that shit up
function CutieRestclearBars()
	local i = 1
	while i  <= 72 do
		PickupAction(i)
		ClearCursor()
		i = i + 1
	end
end

--Arms
function CutieRestputArmsSpellsOnBars()
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
        PickupSpell(spell_list[spellcount])
        PlaceAction(i)
        ClearCursor()
        i = i + 1
    end
end

--Fury
function CutieRestputFurySpellsOnBars()
        print("Fury")
    --[[local i = 1
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
        PickupSpell(spell_list[spellcount])
        PlaceAction(i)
        ClearCursor()
        i = i + 1
    end]]--
end