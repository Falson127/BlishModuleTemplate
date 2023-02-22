﻿using Blish_HUD;
using Blish_HUD.Modules;
using Blish_HUD.Modules.Managers;
using Blish_HUD.Settings;
using Blish_HUD.Content;
using Blish_HUD.Controls;
using Microsoft.Xna.Framework;
using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Falson.SquadRoleRandomizer
{
    [Export(typeof(Blish_HUD.Modules.Module))]
    public class RoleRandomizerMain : Blish_HUD.Modules.Module
    {
        public static StandardWindow RandomizerResultsWindow;
        public static StandardWindow RandomizerSettingsWindow;
        private CornerIcon RandomizerSettingIcon;
        public static List<string> HandKiteValid = new List<string>();
        public static List<string> OilKiteValid = new List<string>();
        public static List<string> FlakKiteValid = new List<string>();
        public static List<string> TankValid = new List<string>();
        public static List<string> HealAlacValid = new List<string>();
        public static List<string> HealQuickValid = new List<string>();
        public static List<string> DPSAlacValid = new List<string>();
        public static List<string> DPSQuickValid = new List<string>();
        public static List<string> MushroomValid = new List<string>();
        public static List<string> TowerValid = new List<string>();
        public static List<string> ReflectValid = new List<string>();
        public static List<string> CannonValid = new List<string>();
        public static List<string> ConstrucPusherValid = new List<string>();
        public static List<string> LampValid = new List<string>();
        public static List<string> PylonValid = new List<string>();
        public static List<string> PillarValid = new List<string>();
        public static List<string> GreenValid = new List<string>();
        public static List<string> SoullessPusherValid = new List<string>();
        public static List<string> DhuumKiteValid = new List<string>();
        public static List<string> QadimKiteValid = new List<string>();
        public static List<string> SwordValid = new List<string>();
        public static List<string> ShieldValid = new List<string>();
        public static Label RandomizationOutputLabel;
        public CounterBox[] CounterBoxes; //need 12 items in this
        public Label[] CounterBoxLabels;
        private StandardButton GenerateRolesButton;
        public SettingCollection InternalPlayerRolesSettings;
        public static SettingEntry<int>[]  CounterBoxesSettings = new SettingEntry<int>[12];
        public static SettingEntry<bool>[] RolesToGenerate = new SettingEntry<bool>[22];
        public static SettingEntry<bool>[] HandKiteRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] OilKiteRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] FlakKiteRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] TankRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] HealAlacRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] HealQuickRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] DPSAlacRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] DPSQuickRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] MushroomRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] TowerRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] ReflectRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] CannonRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] ConstrucPusherRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] LampRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] PylonRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] PillarRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] GreenRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] SoullessPusherRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] DhuumKiteRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] QadimKiteRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] SwordRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] ShieldRoles = new SettingEntry<bool>[10];
        public static SettingEntry<string>[] PlayerNames = new SettingEntry<string>[10];
        public List<CustomCheckbox[]> ListofCheckboxArrays;
        public List<SettingEntry<bool>[]> ListofRolesSettings;
        public static List<List<string>> ListofRoleValidLists;
        public TextBox Player1NameBox;
        public TextBox Player2NameBox;
        public TextBox Player3NameBox;
        public TextBox Player4NameBox;
        public TextBox Player5NameBox;
        public TextBox Player6NameBox;
        public TextBox Player7NameBox;
        public TextBox Player8NameBox;
        public TextBox Player9NameBox;
        public TextBox Player10NameBox;
        public Panel PlayerNameTextBoxPanel;
        public PlayerFlowPanel Player1FlowPanel;
        public PlayerFlowPanel Player2FlowPanel;
        public PlayerFlowPanel Player3FlowPanel;
        public PlayerFlowPanel Player4FlowPanel;
        public PlayerFlowPanel Player5FlowPanel;
        public PlayerFlowPanel Player6FlowPanel;
        public PlayerFlowPanel Player7FlowPanel;
        public PlayerFlowPanel Player8FlowPanel;
        public PlayerFlowPanel Player9FlowPanel;
        public PlayerFlowPanel Player10FlowPanel;
        public FlowPanel MasterFlowPanel;
        public FlowPanel RandomizeCheckboxesPanel;
        public FlowPanel HoT_PlayerRolesPanel1;
        public FlowPanel PoF_PlayerRolesPanel1;
        public FlowPanel HoT_PlayerRolesPanel2;
        public FlowPanel PoF_PlayerRolesPanel2;
        public FlowPanel HoT_PlayerRolesPanel3;
        public FlowPanel PoF_PlayerRolesPanel3;
        public FlowPanel HoT_PlayerRolesPanel4;
        public FlowPanel PoF_PlayerRolesPanel4;
        public FlowPanel HoT_PlayerRolesPanel5;
        public FlowPanel PoF_PlayerRolesPanel5;
        public FlowPanel HoT_PlayerRolesPanel6;
        public FlowPanel PoF_PlayerRolesPanel6;
        public FlowPanel HoT_PlayerRolesPanel7;
        public FlowPanel PoF_PlayerRolesPanel7;
        public FlowPanel HoT_PlayerRolesPanel8;
        public FlowPanel PoF_PlayerRolesPanel8;
        public FlowPanel HoT_PlayerRolesPanel9;
        public FlowPanel PoF_PlayerRolesPanel9;
        public FlowPanel HoT_PlayerRolesPanel10;
        public FlowPanel PoF_PlayerRolesPanel10;
        //Checkbox Arrays
        public CustomCheckbox[] HandKiteBoxArray;
        public CustomCheckbox[] OilKiteBoxArray;
        public CustomCheckbox[] FlakKiteBoxArray;
        public CustomCheckbox[] TankBoxArray;
        public CustomCheckbox[] HealAlacBoxArray; //1-2
        public CustomCheckbox[] HealQuickBoxArray; //1-2
        public CustomCheckbox[] DPSAlacBoxArray; //1-2
        public CustomCheckbox[] DPSQuickBoxArray; //1-2
        public CustomCheckbox[] MushroomBoxArray; //1-4
        public CustomCheckbox[] TowerBoxArray;
        public CustomCheckbox[] ReflectBoxArray;
        public CustomCheckbox[] CannonBoxArray; //1-2
        public CustomCheckbox[] ConstrucPusherBoxArray;
        public CustomCheckbox[] LampBoxArray; //1-3
        public CustomCheckbox[] PylonBoxArray; //1-3
        public CustomCheckbox[] PillarBoxArray; //1-5
        public CustomCheckbox[] GreenBoxArray; //1-2
        public CustomCheckbox[] SoullessPusherBoxArray;
        public CustomCheckbox[] DhuumKiteBoxArray;
        public CustomCheckbox[] QadimKiteBoxArray;
        public CustomCheckbox[] SwordBoxArray; //1-2
        public CustomCheckbox[] ShieldBoxArray; //1-2
        public static CustomCheckbox[] RolestoRandomizeSelectionCheckboxesArray;
        public Panel[] HoTPannelArray;
        public Panel[] PoFPannelArray;
        public Panel RolesWithNumbers;
        

        private static readonly Logger Logger = Logger.GetLogger<RoleRandomizerMain>();

        #region Service Managers
        internal SettingsManager SettingsManager => this.ModuleParameters.SettingsManager;
        internal ContentsManager ContentsManager => this.ModuleParameters.ContentsManager;
        internal DirectoriesManager DirectoriesManager => this.ModuleParameters.DirectoriesManager;
        internal Gw2ApiManager Gw2ApiManager => this.ModuleParameters.Gw2ApiManager;
        #endregion

        [ImportingConstructor]
        public RoleRandomizerMain([Import("ModuleParameters")] ModuleParameters moduleParameters) : base(moduleParameters) { }
        protected override void DefineSettings(SettingCollection settings)
        {   
            InternalPlayerRolesSettings = settings.AddSubCollection("Internal Setting Collection", false);
            InternalPlayerRolesSettings.RenderInUi = false;
            for (int i = 0; i < 12; i++)
            {
                CounterBoxesSettings[i] = InternalPlayerRolesSettings.DefineSetting($"Counter Box {i+1} setting", 1);
            }
            for (int i = 0; i < 22; i++)
            {
                RolesToGenerate[i] = InternalPlayerRolesSettings.DefineSetting($"Role to Generate{i+1} ", false);
            }
            for (int i = 0; i < 10; i++)
            {
                //Build role settings + Playername settings
                HandKiteRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Hand_Kite Player {i+1}" , false);
                OilKiteRoles[i] = InternalPlayerRolesSettings.DefineSetting($"OilKite Player {i+1}" , false);
                FlakKiteRoles[i] = InternalPlayerRolesSettings.DefineSetting($"FlakKite Player {i+1}" , false);
                TankRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Tank Player {i+1}" , false);
                HealAlacRoles[i] = InternalPlayerRolesSettings.DefineSetting($"HealAlac Player {i+1}" , false);
                HealQuickRoles[i] = InternalPlayerRolesSettings.DefineSetting($"HealQuick Player {i+1}" , false);
                DPSAlacRoles[i] = InternalPlayerRolesSettings.DefineSetting($"DPSAlac Player {i+1}" , false);
                DPSQuickRoles[i] = InternalPlayerRolesSettings.DefineSetting($"DPSQuick Player {i+1}" , false);
                MushroomRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Mushroom Player {i+1}" , false);
                TowerRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Tower Player {i+1}" , false);
                ReflectRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Reflect Player {i+1}" , false);
                CannonRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Cannon Player {i+1}" , false);
                ConstrucPusherRoles[i] = InternalPlayerRolesSettings.DefineSetting($"ConstrucPusher Player {i+1}" , false);
                LampRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Lamp Player {i+1}" , false);
                PylonRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Pylon Player {i+1}" , false);
                PillarRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Pillar Player {i+1}" , false);
                GreenRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Green Player {i+1}" , false);
                SoullessPusherRoles[i] = InternalPlayerRolesSettings.DefineSetting($"SoullessPusher Player {i+1}" , false);
                DhuumKiteRoles[i] = InternalPlayerRolesSettings.DefineSetting($"DhuumKite Player {i+1}" , false);
                QadimKiteRoles[i] = InternalPlayerRolesSettings.DefineSetting($"QadimKite Player {i+1}" , false);
                SwordRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Sword Player {i+1}" , false);
                ShieldRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Shield Player {i+1}" , false);
                PlayerNames[i] = InternalPlayerRolesSettings.DefineSetting($"Player {i} Name", $"Player {i}");

            }

        }
        private void GenerateRolesButton_Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            PrepareRoles.PrepRoles();
        }

        protected override async Task LoadAsync()

        {
            CounterBoxes = new CounterBox[12];
            CounterBoxLabels = new Label[12];
            RandomizerSettingsWindow = new StandardWindow(ContentsManager.GetTexture("155985.png"), new Rectangle(40, 26, 913, 691), new Rectangle(70, 71, 839, 605))
            {
                Title = "Randomization Settings",
                Subtitle = "Define Roles to Randomize",
                Parent = GameService.Graphics.SpriteScreen,
                Size = new Point(1050, 800),
                SavesPosition = true,
                Id = "Falson.RoleRandomizer.SettingsWindow"
            };
            RandomizerResultsWindow = new StandardWindow(ContentsManager.GetTexture("155985.png"), new Rectangle(40, 26, 913, 691), new Rectangle(70, 71, 839, 605))
            {
                Title = "Randomized Roles",
                Parent = GameService.Graphics.SpriteScreen,
                Size = new Point(450, 800),
                Location = new Point(100, 100),
                SavesPosition = true,
                Id = "Falson.RoleRandomizer.ResultsWindow"
            };
            RolesWithNumbers = new Panel
            {
                Title = "Number of each role to generate",
                Parent = RandomizerSettingsWindow,
                Size = new Point(480, 165),
                Location = new Point(401, 0),
            };
            GenerateRolesButton = new StandardButton
            {
                Text = "Generate \n  Roles",
                Size = new Point(80, 100),
                Location = new Point(890, 40),
                Parent = RandomizerSettingsWindow,
            };
            GenerateRolesButton.Click += GenerateRolesButton_Click;
            PlayerNameTextBoxPanel = new Panel
            {
                Title = "Enter Player Names",
                Size = new Point(400, 165),
                Location = new Point(0, 0),
                Parent = RandomizerSettingsWindow,
            };
            RandomizeCheckboxesPanel = new FlowPanel
            {
                Title = "Select roles to be randomized",
                Size = new Point(1000, 120),
                Parent = RandomizerSettingsWindow,
                Location = new Point(0, 166),
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            MasterFlowPanel = new FlowPanel
            {
                ShowBorder = true,
                Title = "Set Roles for Each Player  (Click to Expand)",
                Size = new Point(1000, 400),
                Location = new Point(0, 255),
                Parent = RandomizerSettingsWindow,
                CanScroll = true,
                CanCollapse = false,
                FlowDirection = ControlFlowDirection.SingleTopToBottom
            };
            #region Player Panels
            Player1FlowPanel = new PlayerFlowPanel(PlayerNames[0].Value, MasterFlowPanel);
            Player2FlowPanel = new PlayerFlowPanel(PlayerNames[1].Value, MasterFlowPanel);
            Player3FlowPanel = new PlayerFlowPanel(PlayerNames[2].Value, MasterFlowPanel);
            Player4FlowPanel = new PlayerFlowPanel(PlayerNames[3].Value, MasterFlowPanel);
            Player5FlowPanel = new PlayerFlowPanel(PlayerNames[4].Value, MasterFlowPanel);
            Player6FlowPanel = new PlayerFlowPanel(PlayerNames[5].Value, MasterFlowPanel);
            Player7FlowPanel = new PlayerFlowPanel(PlayerNames[6].Value, MasterFlowPanel);
            Player8FlowPanel = new PlayerFlowPanel(PlayerNames[7].Value, MasterFlowPanel);
            Player9FlowPanel = new PlayerFlowPanel(PlayerNames[8].Value, MasterFlowPanel);
            Player10FlowPanel = new PlayerFlowPanel(PlayerNames[9].Value, MasterFlowPanel);
            #endregion
            #region HoT_FlowPanels
            HoT_PlayerRolesPanel1 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player1FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel2 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player2FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel3 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player3FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel4 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player4FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel5 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player5FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel6 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player6FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel7 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player7FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel8 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player8FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel9 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player9FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles",
            };
            HoT_PlayerRolesPanel10 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player10FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            #endregion
            #region PoF_FlowPanels
            PoF_PlayerRolesPanel1 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player1FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel2 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player2FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel3 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player3FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel4 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player4FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel5 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player5FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel6 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player6FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel7 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player7FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel8 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player8FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel9 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player9FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel10 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player10FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            #endregion
            #region Box and Label Arrays
            RolestoRandomizeSelectionCheckboxesArray = new CustomCheckbox[22];
            //RolestoRandomizeSelectionCheckboxesArray = new Checkbox[22] {RandomizeHandKite,RandomizeOilKite,RandomizeFlakKite,RandomizeTank,RandomizeHealAlac,RandomizeHealQuick,RandomizeDPSAlac,RandomizeDPSQuick,RandomizeMushroom,RandomizeTower,RandomizeReflect,RandomizeCannon,RandomizeConstrucPusher,RandomizeLamp,RandomizePylon,RandomizePillar,RandomizeGreen,RandomizeSoullessPusher,RandomizeDhuumKite,RandomizeQadimKite,RandomizeSword,RandomizeShield};
            HandKiteBoxArray = new CustomCheckbox[10];
            OilKiteBoxArray = new CustomCheckbox[10];
            FlakKiteBoxArray = new CustomCheckbox[10];
            TankBoxArray = new CustomCheckbox[10];
            HealAlacBoxArray = new CustomCheckbox[10];
            HealQuickBoxArray = new CustomCheckbox[10];
            DPSAlacBoxArray = new CustomCheckbox[10];
            DPSQuickBoxArray = new CustomCheckbox[10];
            MushroomBoxArray = new CustomCheckbox[10];
            TowerBoxArray = new CustomCheckbox[10];
            ReflectBoxArray = new CustomCheckbox[10];
            CannonBoxArray = new CustomCheckbox[10];
            ConstrucPusherBoxArray = new CustomCheckbox[10];
            LampBoxArray = new CustomCheckbox[10];
            PylonBoxArray = new CustomCheckbox[10];
            PillarBoxArray = new CustomCheckbox[10];
            GreenBoxArray = new CustomCheckbox[10];
            SoullessPusherBoxArray = new CustomCheckbox[10];
            DhuumKiteBoxArray = new CustomCheckbox[10];
            QadimKiteBoxArray = new CustomCheckbox[10];
            SwordBoxArray = new CustomCheckbox[10];
            ShieldBoxArray = new CustomCheckbox[10];
            ListofCheckboxArrays = new List<CustomCheckbox[]> {HandKiteBoxArray,OilKiteBoxArray,FlakKiteBoxArray,TankBoxArray,HealAlacBoxArray,HealQuickBoxArray,DPSAlacBoxArray,DPSQuickBoxArray,MushroomBoxArray,TowerBoxArray,ReflectBoxArray,CannonBoxArray,ConstrucPusherBoxArray,LampBoxArray,PylonBoxArray,PillarBoxArray,GreenBoxArray,SoullessPusherBoxArray,DhuumKiteBoxArray,QadimKiteBoxArray,SwordBoxArray,ShieldBoxArray };
            ListofRolesSettings = new List<SettingEntry<bool>[]> {HandKiteRoles,OilKiteRoles,FlakKiteRoles,TankRoles,HealAlacRoles,HealQuickRoles,DPSAlacRoles,DPSQuickRoles,MushroomRoles,TowerRoles,ReflectRoles,CannonRoles,ConstrucPusherRoles,LampRoles,PylonRoles,PillarRoles,GreenRoles,SoullessPusherRoles,DhuumKiteRoles,QadimKiteRoles,SwordRoles,ShieldRoles };
            ListofRoleValidLists = new List<List<string>> { HandKiteValid,OilKiteValid,FlakKiteValid,TankValid,HealAlacValid,HealQuickValid,DPSAlacValid,DPSQuickValid,MushroomValid,TowerValid,ReflectValid,CannonValid,ConstrucPusherValid,LampValid,PylonValid,PillarValid,GreenValid,SoullessPusherValid,DhuumKiteValid,QadimKiteValid,SwordValid,ShieldValid};
            #endregion
            #region Checkboxes
            HoTPannelArray = new Panel[10] { HoT_PlayerRolesPanel1, HoT_PlayerRolesPanel2, HoT_PlayerRolesPanel3, HoT_PlayerRolesPanel4, HoT_PlayerRolesPanel5, HoT_PlayerRolesPanel6, HoT_PlayerRolesPanel7, HoT_PlayerRolesPanel8, HoT_PlayerRolesPanel9, HoT_PlayerRolesPanel10 };
            PoFPannelArray = new Panel[10] { PoF_PlayerRolesPanel1, PoF_PlayerRolesPanel2, PoF_PlayerRolesPanel3, PoF_PlayerRolesPanel4, PoF_PlayerRolesPanel5, PoF_PlayerRolesPanel6, PoF_PlayerRolesPanel7, PoF_PlayerRolesPanel8, PoF_PlayerRolesPanel9, PoF_PlayerRolesPanel10 };

            for (int i = 0; i < 10; i++)
            {
                HandKiteBoxArray[i] = new CustomCheckbox(HandKiteRoles[i]) { Text = "Hand Kite", Location = new Point(0,0), BasicTooltipText = "Hand Kite", Parent = HoTPannelArray[i], Checked = HandKiteRoles[i].Value };
                OilKiteBoxArray[i] = new CustomCheckbox(OilKiteRoles[i]) { Text = "Oil Kite", Location = new Point(100, 0), BasicTooltipText = "Oil Kite", Parent = HoTPannelArray[i], Checked = OilKiteRoles[i].Value };
                FlakKiteBoxArray[i] = new CustomCheckbox(FlakKiteRoles[i]) { Text = "Flak Kite", Location = new Point(200, 0), BasicTooltipText = "Flak Kite", Parent = HoTPannelArray[i], Checked = FlakKiteRoles[i].Value };
                TankBoxArray[i] = new CustomCheckbox(TankRoles[i]) { Text = "Tank", Location = new Point(300, 0), BasicTooltipText = "Tank", Parent = HoTPannelArray[i], Checked = TankRoles[i].Value };
                HealAlacBoxArray[i] = new CustomCheckbox(HealAlacRoles[i]) { Text = "Heal + Alac", Location = new Point(400, 0), BasicTooltipText = "Heal + Alac", Parent = HoTPannelArray[i], Checked = HealAlacRoles[i].Value };
                HealQuickBoxArray[i] = new CustomCheckbox(HealQuickRoles[i]) { Text = "Heal + Quick", Location = new Point(0, 50), BasicTooltipText = "Heal + Quick", Parent = HoTPannelArray[i], Checked = HealQuickRoles[i].Value };
                DPSAlacBoxArray[i] = new CustomCheckbox(DPSAlacRoles[i]) { Text = "DPS + Alac", Location = new Point(100, 50), BasicTooltipText = "DPS + Alac", Parent = HoTPannelArray[i], Checked = DPSAlacRoles[i].Value };
                DPSQuickBoxArray[i] = new CustomCheckbox(DPSQuickRoles[i]) { Text = "DPS + Quick", Location = new Point(200, 50), BasicTooltipText = "DPS + Quick", Parent = HoTPannelArray[i], Checked = DPSQuickRoles[i].Value };
                MushroomBoxArray[i] = new CustomCheckbox(MushroomRoles[i]) { Text = "Slothosaur Mushroom", Location = new Point(300, 50), BasicTooltipText = "Slothosaur Mushroom", Parent = HoTPannelArray[i], Checked = MushroomRoles[i].Value };
                TowerBoxArray[i] = new CustomCheckbox(TowerRoles[i]) { Text = "Tower Mesmer", Location = new Point(400, 50), BasicTooltipText = "Tower Mesmer", Parent = HoTPannelArray[i], Checked = TowerRoles[i].Value };
                ReflectBoxArray[i] = new CustomCheckbox(ReflectRoles[i]) { Text = "Matthias Reflect", Location = new Point(0, 100), BasicTooltipText = "Matthias Reflect", Parent = HoTPannelArray[i], Checked = ReflectRoles[i].Value };
                CannonBoxArray[i] = new CustomCheckbox(CannonRoles[i]) { Text = "Sabetha Cannons", Location = new Point(100, 100), BasicTooltipText = "Sabetha Cannons", Parent = HoTPannelArray[i], Checked = CannonRoles[i].Value };
                ConstrucPusherBoxArray[i] = new CustomCheckbox(ConstrucPusherRoles[i]) { Text = "Keep Construct Pusher", Location = new Point(200, 100), BasicTooltipText = "Keep Construct Pusher", Parent = HoTPannelArray[i], Checked = ConstrucPusherRoles[i].Value };
                LampBoxArray[i] = new CustomCheckbox(LampRoles[i]) { Text = "Qadim Lamp", Location = new Point(0, 0), BasicTooltipText = "Qadim Lamp", Parent = PoFPannelArray[i], Checked = LampRoles[i].Value };
                PylonBoxArray[i] = new CustomCheckbox(PylonRoles[i]) { Text = "Qadim Pylon", Location = new Point(100, 0), BasicTooltipText = "Qadim Pylon", Parent = PoFPannelArray[i], Checked = PylonRoles[i].Value };
                PillarBoxArray[i] = new CustomCheckbox(PillarRoles[i]) { Text = "Adina Pillar", Location = new Point(200, 0), BasicTooltipText = "Adina Pillar", Parent = PoFPannelArray[i], Checked = PillarRoles[i].Value };
                GreenBoxArray[i] = new CustomCheckbox(GreenRoles[i]) { Text = "Dhuum Green", Location = new Point(300, 0), BasicTooltipText = "Dhuum Green", Parent = PoFPannelArray[i], Checked = GreenRoles[i].Value };
                SoullessPusherBoxArray[i] = new CustomCheckbox(SoullessPusherRoles[i]) { Text = "Soulless Horror Pusher", Location = new Point(400, 0), BasicTooltipText = "Soulless Horror Pusher", Parent = PoFPannelArray[i], Checked = SoullessPusherRoles[i].Value };
                DhuumKiteBoxArray[i] = new CustomCheckbox(DhuumKiteRoles[i]) { Text = "Dhuum Messenger Kiter", Location = new Point(0, 50), BasicTooltipText = "Dhuum Messenger Kiter", Parent = PoFPannelArray[i], Checked = DhuumKiteRoles[i].Value };
                QadimKiteBoxArray[i] = new CustomCheckbox(QadimKiteRoles[i]) { Text = "Qadim Kiter", Location = new Point(100, 50), BasicTooltipText = "Qadim Kiter", Parent = PoFPannelArray[i], Checked = QadimKiteRoles[i].Value };
                SwordBoxArray[i] = new CustomCheckbox(SwordRoles[i]) { Text = "CA Sword Collector", Location = new Point(200, 50), BasicTooltipText = "CA Sword Collector", Parent = PoFPannelArray[i], Checked = SwordRoles[i].Value };
                ShieldBoxArray[i] = new CustomCheckbox(ShieldRoles[i]) { Text = "CA Shield Collector", Location = new Point(300, 50), BasicTooltipText = "CA Shield Collector", Parent = PoFPannelArray[i], Checked = ShieldRoles[i].Value };

            }
            IDictionary<int, string> RandomizeSelectionBoxesInt_to_StringDictionary = new Dictionary<int, string> 
            {
                {0,"Hand Kite"},
                {1,"Oil Kite"},
                {2,"Flak Kite"},
                {3,"Tank"},
                {4,"Heal Alac"},
                {5,"Heal Quickness"},
                {6,"DPS Alac"},
                {7,"DPS Quickness"},
                {8,"Slothosaur Mushrooms"},
                {9,"Tower Mesmer"},
                {10,"Matthias Reflect"},
                {11,"Sabetha Cannons"},
                {12,"Keep Construct Pusher"},
                {13,"Qadim Lamp(s)"},
                {14,"Qadim Pylon(s)"},
                {15,"Adina Pillar(s)"},
                {16,"Dhuum Green(s)"},
                {17,"Soulless Horror Pusher"},
                {18,"Dhuum Messenger Kiter"},
                {19,"Qadim Kite"},
                {20,"Sword Collector(s)"},
                {21,"Shield Collector(s)"},
            };

            IDictionary<int, int> CounterBoxes_MaxAllowedIntValues = new Dictionary<int, int>
            {
                {0, 2},
                {1, 2},
                {2, 2},
                {3, 2},
                {4, 4},
                {5, 2},
                {6, 3},
                {7, 3},
                {8, 5},
                {9, 2},
                {10, 2},
                {11, 2}
            };
            IDictionary<int, string> CounterBoxInt_to_Text = new Dictionary<int, string>
            {
                {0, "# of Heal/Alac"},
                {1, "# of Heal/Quick"},
                {2, "# of DPS/Alac"},
                {3, "# of DPS/Quick"},
                {4, "# of Mushrooms"},
                {5, "# of Cannons"},
                {6, "# of Lamps"},
                {7, "# of Pylons"},
                {8, "# of Pillars"},
                {9, "# of Greens"},
                {10, "# of Swords"},
                {11, "# of Shields"}
            };
            for (int i = 0; i < 22; i++)
            {
                RolestoRandomizeSelectionCheckboxesArray[i] = new CustomCheckbox(RolesToGenerate[i])
                {
                    Text =  RandomizeSelectionBoxesInt_to_StringDictionary[i] + "  ",
                    BasicTooltipText = "Check this box to include " + RandomizeSelectionBoxesInt_to_StringDictionary[i] + " in the randomization",
                    Parent = RandomizeCheckboxesPanel,
                    Checked = RolesToGenerate[i].Value
                };
            }
            #endregion
            #region CounterBoxes
            IDictionary<int, int> CounterBox_X_PositionDictionary = new Dictionary<int, int>
            {
                {0, 100},
                {1, 100},
                {2, 100},
                {3, 100},
                {4, 100},
                {5, 260},
                {6, 260},
                {7, 260},
                {8, 260},
                {9, 260},
                {10, 420},
                {11, 420},
            };
            IDictionary<int, int> CounterBox_Y_PositionDictionary = new Dictionary<int, int>
            {
                {0, 0},
                {1, 25},
                {2, 50},
                {3, 75},
                {4, 100},
                {5, 0},
                {6, 25},
                {7, 50},
                {8, 75},
                {9, 100},
                {10, 0},
                {11, 25},
            };
            for (int i = 0; i<12; i++) 
            {
                CounterBoxes[i] = new CounterBox
                {
                    MaxValue = CounterBoxes_MaxAllowedIntValues[i],
                    Parent = RolesWithNumbers,
                    ValueWidth = 10,
                    Width = 60,
                    BasicTooltipText = CounterBoxInt_to_Text[i],
                    Value = CounterBoxesSettings[i].Value,
                    MinValue = 0,
                    Location = new Point(CounterBox_X_PositionDictionary[i],CounterBox_Y_PositionDictionary[i])
                };
            }
            #endregion
            #region Textboxes
            Player1NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[0].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(0,0)
            };
            Player2NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[1].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(0, 25)
            };
            Player3NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[2].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(0, 50)
            };
            Player4NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[3].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(0, 75)
            };
            Player5NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[4].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(0, 100)
            };
            Player6NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[5].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(200, 0)
            };
            Player7NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[6].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(200, 25)
            };
            Player8NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[7].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(200, 50)
            };
            Player9NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[8].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(200, 75)
            };
            Player10NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[9].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(200, 100)
            };
            #endregion
            #region Labels

            RandomizationOutputLabel = new Label 
            {
            Parent = RandomizerResultsWindow,
            Location = new Point(0,0),
            Size = new Point(375, 650),
            VerticalAlignment = VerticalAlignment.Top
            };
            IDictionary<int, int> CounterBoxLabel_X_PositionDictionary = new Dictionary<int, int> 
            {
                {0, 0},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 160},
                {6, 160},
                {7, 160},
                {8, 160},
                {9, 160},
                {10, 320},
                {11, 320},
            };
            IDictionary<int, int> CounterBoxLabel_Y_PositionDictionary = new Dictionary<int, int>
            {
                {0, 0},
                {1, 25},
                {2, 50},
                {3, 75},
                {4, 100},
                {5, 0},
                {6, 25},
                {7, 50},
                {8, 75},
                {9, 100},
                {10, 0},
                {11, 25},
            };

            CounterBoxLabels = new Label[12];
            for (int i = 0; i < 12; i++)
            {
                CounterBoxLabels[i] = new Label 
                {
                    Text = CounterBoxInt_to_Text[i],
                    Size = new Point(100,25),
                    Location = new Point(CounterBoxLabel_X_PositionDictionary[i],CounterBoxLabel_Y_PositionDictionary[i]),
                    Parent = RolesWithNumbers
                };
            }
            #endregion
            Player1NameBox.TextChanged += Player1NameBox_TextChanged;
            Player2NameBox.TextChanged += Player2NameBox_TextChanged;
            Player3NameBox.TextChanged += Player3NameBox_TextChanged;
            Player4NameBox.TextChanged += Player4NameBox_TextChanged;
            Player5NameBox.TextChanged += Player5NameBox_TextChanged;
            Player6NameBox.TextChanged += Player6NameBox_TextChanged;
            Player7NameBox.TextChanged += Player7NameBox_TextChanged;
            Player8NameBox.TextChanged += Player8NameBox_TextChanged;
            Player9NameBox.TextChanged += Player9NameBox_TextChanged;
            Player10NameBox.TextChanged += Player10NameBox_TextChanged;
            CounterBoxes[0].Click += CounterBox1Click;
            CounterBoxes[1].Click += CounterBox2Click;
            CounterBoxes[2].Click += CounterBox3Click;
            CounterBoxes[3].Click += CounterBox4Click;
            CounterBoxes[4].Click += CounterBox5Click;
            CounterBoxes[5].Click += CounterBox6Click;
            CounterBoxes[6].Click += CounterBox7Click;
            CounterBoxes[7].Click += CounterBox8Click;
            CounterBoxes[8].Click += CounterBox9Click;
            CounterBoxes[9].Click += CounterBox10Click;
            CounterBoxes[10].Click += CounterBox11Click;
            CounterBoxes[11].Click += CounterBox12Click;
        }
        #region CounterBox Click Functions
        private void CounterBox12Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[11].Value = CounterBoxes[11].Value;
        }

        private void CounterBox11Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[10].Value = CounterBoxes[10].Value;
        }

        private void CounterBox10Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[9].Value = CounterBoxes[9].Value;
        }

        private void CounterBox9Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[8].Value = CounterBoxes[8].Value;
        }

        private void CounterBox8Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[7].Value = CounterBoxes[7].Value;
        }

        private void CounterBox7Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[6].Value = CounterBoxes[6].Value;
        }

        private void CounterBox6Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[5].Value = CounterBoxes[5].Value;
        }

        private void CounterBox5Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[4].Value = CounterBoxes[4].Value;
        }

        private void CounterBox4Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[3].Value = CounterBoxes[3].Value;
        }

        private void CounterBox3Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[2].Value = CounterBoxes[2].Value;
        }

        private void CounterBox2Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[1].Value = CounterBoxes[1].Value;
        }

        private void CounterBox1Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[0].Value = CounterBoxes[0].Value;
        }
        #endregion
        #region Textbox text changed functions
        private void Player10NameBox_TextChanged(object sender, EventArgs e)
        {
            Player10FlowPanel.Title = Player10NameBox.Text;
            PlayerNames[9].Value = Player10NameBox.Text;
            if (Player10NameBox.Text == "") 
            {
                Player10NameBox.Text = "Enter Player Name...";
            }

        }

        private void Player9NameBox_TextChanged(object sender, EventArgs e)
        {
            Player9FlowPanel.Title = Player9NameBox.Text;
            PlayerNames[8].Value = Player9NameBox.Text;
            if(Player9NameBox.Text == "") 
            {
                Player9NameBox.Text = "Enter Player Name...";
            }
        }

        private void Player8NameBox_TextChanged(object sender, EventArgs e)
        {
            Player8FlowPanel.Title = Player8NameBox.Text;
            PlayerNames[7].Value = Player8NameBox.Text;
            if(Player8NameBox.Text == "") 
            {
                Player8NameBox.Text = "Enter Player Name...";
            }
        }

        private void Player7NameBox_TextChanged(object sender, EventArgs e)
        {
            Player7FlowPanel.Title = Player7NameBox.Text;
            PlayerNames[6].Value = Player7NameBox.Text;
            if(Player7NameBox.Text == "") 
            {
                Player7NameBox.Text = "Enter Player Name...";
            }
        }

        private void Player6NameBox_TextChanged(object sender, EventArgs e)
        {
            Player6FlowPanel.Title = Player6NameBox.Text;
            PlayerNames[5].Value = Player6NameBox.Text;
            if(Player6NameBox.Text == "") 
            {
                Player6NameBox.Text = "Enter Player Name...";
            }
        }

        private void Player5NameBox_TextChanged(object sender, EventArgs e)
        {
            Player5FlowPanel.Title = Player5NameBox.Text;
            PlayerNames[4].Value = Player5NameBox.Text;
            if(Player5NameBox.Text == "") 
            {
                Player5NameBox.Text = "Enter Player Name...";
            }
        }

        private void Player4NameBox_TextChanged(object sender, EventArgs e)
        {
            Player4FlowPanel.Title = Player4NameBox.Text;
            PlayerNames[3].Value = Player4NameBox.Text;
            if(Player4NameBox.Text == "") 
            {
                Player4NameBox.Text = "Enter Player Name...";
            }
        }

        private void Player3NameBox_TextChanged(object sender, EventArgs e)
        {
            Player3FlowPanel.Title = Player3NameBox.Text;
            PlayerNames[2].Value = Player3NameBox.Text;
            if(Player3NameBox.Text == "") 
            {
                Player3NameBox.Text = "Enter Player Name...";
            }
        }

        private void Player2NameBox_TextChanged(object sender, EventArgs e)
        {
            Player2FlowPanel.Title = Player2NameBox.Text;
            PlayerNames[1].Value = Player2NameBox.Text;
            if(Player2NameBox.Text == "") 
            {
                Player2NameBox.Text = "Enter Player Name...";
            }
        }

        private void Player1NameBox_TextChanged(object sender, EventArgs e)
        {
            Player1FlowPanel.Title = Player1NameBox.Text;
            PlayerNames[0].Value = Player1NameBox.Text;
            if(Player1NameBox.Text == "") 
            {
                Player1NameBox.Text = "Enter Player Name...";
            }
        }
        #endregion
        protected override void OnModuleLoaded(EventArgs e)
        {
            //GenerateRoles.RandomizeTheRoles();
            RandomizerSettingIcon = new CornerIcon 
            {
                Icon = ContentsManager.GetTexture("Emblem.png"),
                BasicTooltipText = "Click to open settings window"
            };
            RandomizerSettingIcon.Click += delegate 
            {
                RandomizerSettingsWindow.ToggleWindow();

            };



            // Base handler must be called
            base.OnModuleLoaded(e);
        }

        protected override void Update(GameTime gameTime)
        {

        }

        /// <inheritdoc />
        protected override void Unload()
        {
            #region Disposables
            #region Checkboxes
            foreach (var item in CounterBoxes)
            {
                item?.Dispose();
            }
            foreach (var item in CounterBoxLabels)
            {
                item?.Dispose();
            }
            foreach (var item in HandKiteBoxArray) 
            {
                item?.Dispose();
            }
            foreach(var item in OilKiteBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in FlakKiteBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in TankBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in HealAlacBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in HealQuickBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in DPSAlacBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in DPSQuickBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in MushroomBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in TowerBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in ReflectBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in CannonBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in ConstrucPusherBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in LampBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in PylonBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in PillarBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in GreenBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in SoullessPusherBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in DhuumKiteBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in QadimKiteBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in SwordBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in ShieldBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in RolestoRandomizeSelectionCheckboxesArray)
            {
                item?.Dispose();
            }
            foreach(var item in HoTPannelArray)
            {
                item?.Dispose();
            }
            foreach(var item in PoFPannelArray)
            {
                item?.Dispose();
            }
            #endregion
            RandomizerSettingIcon?.Dispose();
            RandomizerResultsWindow?.Dispose();
            RandomizerSettingsWindow?.Dispose();
            MasterFlowPanel?.Dispose();
            GenerateRolesButton?.Dispose();
            Player1NameBox?.Dispose();
            Player2NameBox?.Dispose();
            Player3NameBox?.Dispose();
            Player4NameBox?.Dispose();
            Player5NameBox?.Dispose();
            Player6NameBox?.Dispose();
            Player7NameBox?.Dispose();
            Player8NameBox?.Dispose();
            Player9NameBox?.Dispose();
            Player10NameBox?.Dispose();
            PlayerNameTextBoxPanel?.Dispose();
            Player1FlowPanel?.Dispose();
            Player2FlowPanel?.Dispose();
            Player3FlowPanel?.Dispose();
            Player4FlowPanel?.Dispose();
            Player5FlowPanel?.Dispose();
            Player6FlowPanel?.Dispose();
            Player7FlowPanel?.Dispose();
            Player8FlowPanel?.Dispose();
            Player9FlowPanel?.Dispose();
            Player10FlowPanel?.Dispose();
            MasterFlowPanel?.Dispose();
            RandomizeCheckboxesPanel?.Dispose();
            HoT_PlayerRolesPanel1?.Dispose();
            PoF_PlayerRolesPanel1?.Dispose();
            HoT_PlayerRolesPanel2?.Dispose();
            PoF_PlayerRolesPanel2?.Dispose();
            HoT_PlayerRolesPanel3?.Dispose();
            PoF_PlayerRolesPanel3?.Dispose();
            HoT_PlayerRolesPanel4?.Dispose();
            PoF_PlayerRolesPanel4?.Dispose();
            HoT_PlayerRolesPanel5?.Dispose();
            PoF_PlayerRolesPanel5?.Dispose();
            HoT_PlayerRolesPanel6?.Dispose();
            PoF_PlayerRolesPanel6?.Dispose();
            HoT_PlayerRolesPanel7?.Dispose();
            PoF_PlayerRolesPanel7?.Dispose();
            HoT_PlayerRolesPanel8?.Dispose();
            PoF_PlayerRolesPanel8?.Dispose();
            HoT_PlayerRolesPanel9?.Dispose();
            PoF_PlayerRolesPanel9?.Dispose();
            HoT_PlayerRolesPanel10?.Dispose();
            PoF_PlayerRolesPanel10?.Dispose();
            #endregion
            #region Static Members
            HandKiteValid = null;
            OilKiteValid = null;
            FlakKiteValid = null;
            TankValid = null;
            HealAlacValid = null;
            HealQuickValid = null;
            DPSAlacValid = null;
            DPSQuickValid = null;
            MushroomValid = null;
            TowerValid = null;
            ReflectValid = null;
            CannonValid = null;
            ConstrucPusherValid = null;
            LampValid = null;
            PylonValid = null;
            PillarValid = null;
            GreenValid = null;
            SoullessPusherValid = null;
            DhuumKiteValid = null;
            QadimKiteValid = null;
            SwordValid = null;
            ShieldValid = null;
            RandomizationOutputLabel = null;
            CounterBoxesSettings = null;
            RolesToGenerate = null;
            HandKiteRoles = null;
            OilKiteRoles = null;
            FlakKiteRoles = null;
            TankRoles = null;
            HealAlacRoles = null;
            HealQuickRoles = null;
            DPSAlacRoles = null;
            DPSQuickRoles = null;
            MushroomRoles = null;
            TowerRoles = null;
            ReflectRoles = null;
            CannonRoles = null;
            ConstrucPusherRoles = null;
            LampRoles = null;
            PylonRoles = null;
            PillarRoles = null;
            GreenRoles = null;
            SoullessPusherRoles = null;
            DhuumKiteRoles = null;
            QadimKiteRoles = null;
            SwordRoles = null;
            ShieldRoles = null;
            for (int i = 0; i < 10; i++)
            {
                PlayerNames[i] = null;
            }
            ListofRoleValidLists = null;
            RolestoRandomizeSelectionCheckboxesArray = null;
            Randomizer.Randomizer.RoleName_to_SelectedPlayer = null;
            #endregion
            #region Events
            Player1NameBox.TextChanged -= Player1NameBox_TextChanged;
            Player2NameBox.TextChanged -= Player2NameBox_TextChanged;
            Player3NameBox.TextChanged -= Player3NameBox_TextChanged;
            Player4NameBox.TextChanged -= Player4NameBox_TextChanged;
            Player5NameBox.TextChanged -= Player5NameBox_TextChanged;
            Player6NameBox.TextChanged -= Player6NameBox_TextChanged;
            Player7NameBox.TextChanged -= Player7NameBox_TextChanged;
            Player8NameBox.TextChanged -= Player8NameBox_TextChanged;
            Player9NameBox.TextChanged -= Player9NameBox_TextChanged;
            Player10NameBox.TextChanged -= Player10NameBox_TextChanged;
            CounterBoxes[0].Click -= CounterBox1Click;
            CounterBoxes[1].Click -= CounterBox2Click;
            CounterBoxes[2].Click -= CounterBox3Click;
            CounterBoxes[3].Click -= CounterBox4Click;
            CounterBoxes[4].Click -= CounterBox5Click;
            CounterBoxes[5].Click -= CounterBox6Click;
            CounterBoxes[6].Click -= CounterBox7Click;
            CounterBoxes[7].Click -= CounterBox8Click;
            CounterBoxes[8].Click -= CounterBox9Click;
            CounterBoxes[9].Click -= CounterBox10Click;
            CounterBoxes[10].Click -= CounterBox11Click;
            CounterBoxes[11].Click -= CounterBox12Click;
            GenerateRolesButton.Click -= GenerateRolesButton_Click;
            RandomizerSettingIcon.Click -= delegate{RandomizerSettingsWindow.Show();};
            #endregion
        }
    }
}

