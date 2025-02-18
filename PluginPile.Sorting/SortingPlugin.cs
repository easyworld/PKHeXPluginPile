using PKHeX.Core;
using PluginPile.Common;
using System.Reflection;

namespace PluginPile.Sorting; 
public class SortingPlugin : PluginBase {
  public override string Name => nameof(SortingPlugin);
  protected override Assembly PluginAssembly => typeof(SortingPlugin).Assembly;
  private readonly ToolStripMenuItem SortByButton;

  public SortingPlugin() {
    SortByButton = new ToolStripMenuItem(Language.MenuItemName) {
      Image = Properties.Images.SortIcon
    };
  }

  protected override void HandleSaveLoaded() => ReloadMenu();

  protected override void LoadMenu(ToolStripDropDownItem tools) {
    tools.DropDownItems.Add(SortByButton);
    SetSortItems();
  }

  private void SetSortItems() {
    SortByButton.DropDownItems.Clear();
    ToolStripItemCollection sortItems = SortByButton.DropDownItems;
    int gen = SaveFileEditor.SAV.Generation;
    GameVersion version = SaveFileEditor.SAV.Version;
    bool isLetsGo = version == GameVersion.GP || version == GameVersion.GE;
    if (isLetsGo) {
      sortItems.Add(GetRegionalSortButton(Language.Gen7Kanto, Gen7_Kanto.GetSortFunctions()));
    } else {
      bool isBDSP = version == GameVersion.BD || version == GameVersion.SP;
      bool isPLA  = version == GameVersion.PLA;

      if (gen >= 1) {
        sortItems.Add(GetRegionalSortButton(Language.Gen1Kanto, Gen1_Kanto.GetSortFunctions()));
      }

      if (gen >= 2) {
        sortItems.Add(GetRegionalSortButton(Language.Gen2Johto, Gen2_Johto.GetSortFunctions()));
      }

      if (gen >= 3) {
        sortItems.Add(GetRegionalSortButton(Language.Gen3Hoenn, Gen3_Hoenn.GetSortFunctions()));
        sortItems.Add(GetRegionalSortButton(Language.Gen3Kanto, Gen3_Kanto.GetSortFunctions()));
      }

      if (gen >= 4) {
        sortItems.Add(GetRegionalSortButton(Language.Gen4SinnohDiamondPearl, Gen4_Sinnoh.GetDPSortFunctions()));
        sortItems.Add(GetRegionalSortButton(Language.Gen4SinnohPlatinum, Gen4_Sinnoh.GetPtSortFunctions()));
        sortItems.Add(GetRegionalSortButton(Language.Gen4Johto, Gen4_Johto.GetSortFunctions()));
      }

      if (gen >= 5 && !isBDSP) {
        sortItems.Add(GetRegionalSortButton(Language.Gen5UnovaBlackWhite, Gen5_Unova.GetBWSortFunctions()));
        sortItems.Add(GetRegionalSortButton(Language.Gen5UnovaBlack2White2, Gen5_Unova.GetB2W2SortFunctions()));
      }

      if (gen >= 6 && !isBDSP) {
        if (PluginSettings.Default.ShowIndividualPokedéxes) {
          sortItems.Add(GetAreaButtons(Language.Gen6KalosAreas, new ToolStripItem[] {
            GetRegionalSortButton(Language.Gen6KalosAreasCentralKalos, Gen6_Kalos.GetCentralDexSortFunctions()),
            GetRegionalSortButton(Language.Gen6KalosAreasCostalKalos, Gen6_Kalos.GetCostalDexSortFunctions()),
            GetRegionalSortButton(Language.Gen6KalosAreasMountainKalos, Gen6_Kalos.GetMountainDexSortFunctions())
          }));
        }
        sortItems.Add(GetRegionalSortButton(Language.Gen6Kalos, Gen6_Kalos.GetSortFunctions()));
        sortItems.Add(GetRegionalSortButton(Language.Gen6Hoenn, Gen6_Hoenn.GetSortFunctions()));
      }

      if (gen >= 7 && !isBDSP && !isPLA) {
        if (PluginSettings.Default.ShowIndividualPokedéxes) {
          sortItems.Add(GetAreaButtons(Language.Gen7AlolaSunMoonIslands, new ToolStripItem[] {
            GetRegionalSortButton(Language.Gen7AlolaIslandsMelemele, Gen7_Alola.GetSMMelemeleSortFunctions()),
            GetRegionalSortButton(Language.Gen7AlolaIslandsAkala, Gen7_Alola.GetSMAkalaSortFunctions()),
            GetRegionalSortButton(Language.Gen7AlolaIslandsUlaula, Gen7_Alola.GetSMUlaulaSortFunctions()),
            GetRegionalSortButton(Language.Gen7AlolaIslandsPoni, Gen7_Alola.GetSMPoniSortFunctions())
          }));
        }
        sortItems.Add(GetRegionalSortButton(Language.Gen7AlolaSunMoon, Gen7_Alola.GetSMSortFunctions()));
        if (PluginSettings.Default.ShowIndividualPokedéxes) {
          sortItems.Add(GetAreaButtons(Language.Gen7AlolaUltraSunUltraMoonIslands, new ToolStripItem[] {
            GetRegionalSortButton(Language.Gen7AlolaIslandsMelemele, Gen7_Alola.GetUSUMMelemeleSortFunctions()),
            GetRegionalSortButton(Language.Gen7AlolaIslandsAkala, Gen7_Alola.GetUSUMAkalaSortFunctions()),
            GetRegionalSortButton(Language.Gen7AlolaIslandsUlaula, Gen7_Alola.GetUSUMUlaulaSortFunctions()),
            GetRegionalSortButton(Language.Gen7AlolaIslandsPoni, Gen7_Alola.GetUSUMPoniSortFunctions())
          }));
        }
        sortItems.Add(GetRegionalSortButton(Language.Gen7AlolaUltraSunUltraMoon, Gen7_Alola.GetUSUMSortFunctions()));
      }

      if (gen >= 8) {
        bool isSwSh = version == GameVersion.SW || version == GameVersion.SH;
        if (!isBDSP && !isPLA) {
          bool isScVi = version == GameVersion.SL || version == GameVersion.VL;
          if (!isScVi) {
            sortItems.Add(GetRegionalSortButton(Language.Gen7Kanto, Gen7_Kanto.GetSortFunctions()));
          }
          if (PluginSettings.Default.ShowIndividualPokedéxes) {
            sortItems.Add(GetAreaButtons(Language.Gen8GalarAreas, new ToolStripItem[] {
              GetRegionalSortButton(Language.Gen8GalarAreasGalar, Gen8_Galar.GetGalarDexSortFunctions()),
              GetRegionalSortButton(Language.Gen8GalarAreasIsleofArmor, Gen8_Galar.GetIoADexSortFunctions()),
              GetRegionalSortButton(Language.Gen8GalarAreasCrownTundra, Gen8_Galar.GetCTDexSortFunction())
            }));
          }
          sortItems.Add(GetRegionalSortButton(Language.Gen8Galar, Gen8_Galar.GetFullGalarDexSortFunctions()));
        }
        if (!isSwSh) {
          sortItems.Add(GetRegionalSortButton(Language.Gen8Sinnoh, Gen8_Sinnoh.GetSortFunctions()));
          if (!isBDSP) {
            if (PluginSettings.Default.ShowIndividualPokedéxes) {
              sortItems.Add(GetAreaButtons(Language.Gen8HisuiAreas, new ToolStripItem[] {
                GetRegionalSortButton(Language.Gen8HisuiAreasObsidianFieldlands, Gen8_Hisui.GetObsidianFieldlandsSortFunctions()),
                GetRegionalSortButton(Language.Gen8HisuiAreasCrimsonMirelands, Gen8_Hisui.GetCrimsonMirelandsSortFunctions()),
                GetRegionalSortButton(Language.Gen8HisuiAreasCobaltCoastlands, Gen8_Hisui.GetCobaltCoastlandsSortFunctions()),
                GetRegionalSortButton(Language.Gen8HisuiAreasCoronetHighlands, Gen8_Hisui.GetCoronetHighlandsSortFunctions()),
                GetRegionalSortButton(Language.Gen8HisuiAreasAlabasterIcelands, Gen8_Hisui.GetAlabasterIcelandsSortFunctions())
              }));
            }
            sortItems.Add(GetRegionalSortButton(Language.Gen8Hisui, Gen8_Hisui.GetSortFunctions()));
          }
        }
      }

      if (gen >= 9) {
        if (PluginSettings.Default.ShowIndividualPokedéxes) {
          sortItems.Add(GetAreaButtons(Language.Gen9PaldeaRegions, new ToolStripItem[] {
            GetRegionalSortButton(Language.Gen9PaldeaRegionsPaldea, Gen9_Paldea.GetPaldeaSortFunctions()),
            GetRegionalSortButton(Language.Gen9PaldeaRegionsKitakami, Gen9_Paldea.GetKitakamiSortFunctions())
          }));
        }
        sortItems.Add(GetRegionalSortButton(Language.Gen9Paldea, Gen9_Paldea.GetSortFunctions()));
      }

      if (gen != 1) {
        ToolStripMenuItem nationalDexSortButton = new ToolStripMenuItem(Language.NationalPokédex);
        nationalDexSortButton.Click += (s, e) => SortByFunctions();
        sortItems.Add(nationalDexSortButton);

        if (gen >= 7 && !isBDSP) {
          ToolStripMenuItem nationalDexWithFormSortButton = new ToolStripMenuItem(Language.NationalPokédexRegionalForms);
          nationalDexWithFormSortButton.Click += (s, e) => SortByFunctions(Gen_National.GetNationalDexWithRegionalFormsSortFunctions());
          sortItems.Add(nationalDexWithFormSortButton);
        }
      }
    }

    ToolStripMenuItem settingsButton = new ToolStripMenuItem(Language.Settings);
    settingsButton.Click += (s, e) => new SettingsForm(this).ShowDialogInParent();
    sortItems.Add(settingsButton);
  }


  public void ReloadMenu() => SetSortItems();

  private void SortByFunctions(Func<PKM, IComparable>[]? sortFunctions = null) {
    int beginIndex = PluginSettings.Default.SortBeginBox - 1;
    int endIndex = PluginSettings.Default.SortEndBox < 0 ? -1 : PluginSettings.Default.SortEndBox - 1;
    if (sortFunctions != null) {
      IEnumerable<PKM> sortMethod(IEnumerable<PKM> pkms, int start) => pkms.OrderByCustom(sortFunctions);
      SaveFileEditor.SAV.SortBoxes(beginIndex, endIndex, sortMethod);
    } else {
      SaveFileEditor.SAV.SortBoxes(beginIndex, endIndex);
    }
    SaveFileEditor.ReloadSlots();
  }

  private ToolStripItem GetRegionalSortButton(string dex, Func<PKM, IComparable>[] sortFunctions) {
    ToolStripMenuItem dexSortButton = new ToolStripMenuItem(string.Format(Language.RegionalPokédexTemplate, dex));
    dexSortButton.Click += (s, e) => SortByFunctions(sortFunctions);
    return dexSortButton;
  }

  private static ToolStripMenuItem GetAreaButtons(string name, ToolStripItem[] sortButtons) {
    ToolStripMenuItem areas = new ToolStripMenuItem(name);
    areas.DropDownItems.AddRange(sortButtons);
    return areas;
  }

  protected override void LoadContextMenu(ContextMenuStrip contextMenu) {
    contextMenu.Opening += (s, e) => {
      SlotViewInfo<PictureBox> info = GetSenderInfo(ref s!);
      if (info.IsNonEmptyWriteableBoxSlot()) {
        ToolStripMenuItem insertSlotButton = new ToolStripMenuItem(Language.InsertSlot);
        insertSlotButton.Click += (s, e) => InsertSlot(SaveFileEditor.CurrentBox, info.Slot.Slot);
        contextMenu.Items.Add(insertSlotButton);
        contextMenu.Closing += (s, e) => contextMenu.Items.Remove(insertSlotButton);
      }
    };
  }

  private void InsertSlot(int boxNum, int slotNum) {
    int startIndex = boxNum * SaveFileEditor.SAV.BoxSlotCount + slotNum;
    int boxIndex = startIndex + 1;
    PKM currMon, nextMon;
    while (boxIndex < SaveFileEditor.SAV.SlotCount) {
      currMon = SaveFileEditor.SAV.GetBoxSlotAtIndex(boxIndex);
      if (currMon.Species == (int)Species.None) break;
      boxIndex++;
    }
    if (boxIndex == SaveFileEditor.SAV.SlotCount) {
      MessageBox.Show(string.Format(Language.NoEmptySlotsError, boxNum + 1, slotNum + 1), Language.InsertSlot, MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }
    currMon = SaveFileEditor.SAV.GetBoxSlotAtIndex(startIndex);
    SaveFileEditor.SAV.SetBoxSlotAtIndex(SaveFileEditor.SAV.BlankPKM, startIndex);
    for (int index = startIndex + 1; index <= boxIndex; index++) {
      StorageSlotSource slotSource = SaveFileEditor.SAV.GetSlotFlags(index);
      if (slotSource.IsOverwriteProtected()) continue;
      nextMon = SaveFileEditor.SAV.GetBoxSlotAtIndex(index);
      SaveFileEditor.SAV.SetBoxSlotAtIndex(currMon, index, PKMImportSetting.UseDefault, PKMImportSetting.Skip);
      currMon = nextMon;
    }
    SaveFileEditor.ReloadSlots();
  }

}
