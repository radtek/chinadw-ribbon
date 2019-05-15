using DevExpress.XtraBars.Localization;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;

//using DevExpress.XtraNavBar;

namespace BSB.Common
{
  /// <summary>
  ///   Summary description for RussianResource.
  /// </summary>
  public enum LanguageIds
  {
    Root = 44,
    English = 47,
    Russian = 46,
    Kazakh = 45
  }

  public class DevExpResource
  {
    public static void SetLanguage(LanguageIds ids)
    {
      switch (ids)
      {
        case LanguageIds.Russian:
          GridLocalizer.Active = new RussianGridLocalizer();
          Localizer.Active = new RussianEditorsLocalizer();
          BarLocalizer.Active = new RussianBarLocalizer();
          //DevExpress.XtraNavBar.NavBarLocalizer.Active = new RussianNavBarLocalizer();
          break;
        case LanguageIds.English:
          GridLocalizer.Active = new GridLocalizer();
          Localizer.Active = new Localizer();
          BarLocalizer.Active = new BarLocalizer();
          //DevExpress.XtraNavBar.NavBarLocalizer.Active = new NavBarLocalizer();
          break;
        case LanguageIds.Kazakh:
          GridLocalizer.Active = new KazakhGridLocalizer();
          Localizer.Active = new KazakhEditorsLocalizer();
          BarLocalizer.Active = new KazakhBarLocalizer();
          //DevExpress.XtraNavBar.NavBarLocalizer.Active = new KazakhNavBarLocalizer();
          break;
        default:
          GridLocalizer.Active = new GridLocalizer();
          Localizer.Active = new Localizer();
          BarLocalizer.Active = new BarLocalizer();
          //DevExpress.XtraNavBar.NavBarLocalizer.Active = new NavBarLocalizer();
          break;
      }
    }
  }

  // ������� �������
  internal class RussianGridLocalizer : GridLocalizer
  {
    // overriding the GetLocalizedString method
    public override string GetLocalizedString(GridStringId id)
    {
      switch (id)
      {
        case GridStringId.GridGroupPanelText:
          return LangTranslate.UiGetText("��������� ���� ��������� �������, ����� ������������� �� ������ �������");
        case GridStringId.ColumnViewExceptionMessage:
          return LangTranslate.UiGetText("�� ������ ��������������� ��������?");
        case GridStringId.CustomFilterDialog2FieldCheck:
          return "2";
        case GridStringId.CustomFilterDialogCancelButton:
          return LangTranslate.UiGetText("������");
        case GridStringId.CustomFilterDialogCaption:
          return LangTranslate.UiGetText("�������� ������ ���:");
        //case  GridStringId.CustomFilterDialogConditionBlanks: return LangTranslate.UIGetText("�����");
        //case  GridStringId.CustomFilterDialogConditionEQU: return LangTranslate.UIGetText("�����");
        //case  GridStringId.CustomFilterDialogConditionGT: return LangTranslate.UIGetText("������ ���");
        //case  GridStringId.CustomFilterDialogConditionGTE: return LangTranslate.UIGetText("������ ��� �����");
        //case  GridStringId.CustomFilterDialogConditionLike: return LangTranslate.UIGetText("�������");
        //case  GridStringId.CustomFilterDialogConditionLT: return LangTranslate.UIGetText("������ ���");
        //case  GridStringId.CustomFilterDialogConditionLTE: return LangTranslate.UIGetText("������ ��� �����");
        //case  GridStringId.CustomFilterDialogConditionNEQ: return LangTranslate.UIGetText("�� �����");
        //case  GridStringId.CustomFilterDialogConditionNonBlanks: return LangTranslate.UIGetText("�� �����");
        //case  GridStringId.CustomFilterDialogConditionNotLike: return LangTranslate.UIGetText("�� �������");
        case GridStringId.CustomFilterDialogFormCaption:
          return LangTranslate.UiGetText("��������� �������");
        case GridStringId.CustomFilterDialogRadioAnd:
          return LangTranslate.UiGetText("�");
        case GridStringId.CustomFilterDialogRadioOr:
          return LangTranslate.UiGetText("���");
        case GridStringId.CustomizationBands:
          return "18";
        case GridStringId.CustomizationCaption:
          return LangTranslate.UiGetText("��������� �������");
        case GridStringId.CustomizationColumns:
          return "20";
        case GridStringId.FileIsNotFoundError:
          return LangTranslate.UiGetText("������: ���� �� ������");
        case GridStringId.MenuColumnBestFit:
          return LangTranslate.UiGetText("������ ������������");
        case GridStringId.MenuColumnBestFitAllColumns:
          return LangTranslate.UiGetText("������ ������������ (��� �������)");
        case GridStringId.MenuColumnClearFilter:
          return LangTranslate.UiGetText("������ ������");
        case GridStringId.MenuColumnColumnCustomization:
          return LangTranslate.UiGetText("��������� �������");
        case GridStringId.MenuColumnFilter:
          return LangTranslate.UiGetText("������");
        case GridStringId.MenuColumnGroup:
          return LangTranslate.UiGetText("����������� �� �������");
        case GridStringId.MenuColumnSortAscending:
          return LangTranslate.UiGetText("����������� �� �����������");
        case GridStringId.MenuColumnSortDescending:
          return LangTranslate.UiGetText("����������� �� ��������");
        case GridStringId.MenuColumnUnGroup:
          return "30";
        case GridStringId.MenuFooterAverage:
          return LangTranslate.UiGetText("�������");
        case GridStringId.MenuFooterAverageFormat:
          return "32";
        case GridStringId.MenuFooterCount:
          return LangTranslate.UiGetText("����������");
        case GridStringId.MenuFooterCountFormat:
          return "34";
        case GridStringId.MenuFooterMax:
          return LangTranslate.UiGetText("��������");
        case GridStringId.MenuFooterMaxFormat:
          return "36";
        case GridStringId.MenuFooterMin:
          return LangTranslate.UiGetText("�������");
        case GridStringId.MenuFooterMinFormat:
          return "38";
        case GridStringId.MenuFooterNone:
          return LangTranslate.UiGetText("�����");
        case GridStringId.MenuFooterSum:
          return LangTranslate.UiGetText("�����");
        case GridStringId.MenuFooterSumFormat:
          return "41";
        case GridStringId.MenuGroupPanelClearGrouping:
          return LangTranslate.UiGetText("������ �����������");
        case GridStringId.MenuGroupPanelFullCollapse:
          return LangTranslate.UiGetText("��������� ��������");
        case GridStringId.MenuGroupPanelFullExpand:
          return LangTranslate.UiGetText("���������� ��������");
        case GridStringId.PopupFilterAll:
          return LangTranslate.UiGetText("(���)");
        case GridStringId.PopupFilterBlanks:
          return LangTranslate.UiGetText("(������)");
        case GridStringId.PopupFilterCustom:
          return LangTranslate.UiGetText("(���������...)");
        case GridStringId.PopupFilterNonBlanks:
          return LangTranslate.UiGetText("(�� ������)");
        case GridStringId.PrintDesignerBandedView:
          return "49";
        case GridStringId.PrintDesignerBandHeader:
          return "50";
        case GridStringId.PrintDesignerCardView:
          return "51";
        case GridStringId.PrintDesignerGridView:
          return "52";
        case GridStringId.WindowErrorCaption:
          return LangTranslate.UiGetText("������");
        case GridStringId.MenuColumnGroupBox:
          return LangTranslate.UiGetText("������ �����������");
        case GridStringId.GridNewRowText:
          return LangTranslate.UiGetText("������� �����, ����� �������� ������");
        case GridStringId.GridOutlookIntervals:
          return
            LangTranslate.UiGetText(
              "������;������� �����;��� ������ �����;��� ������ �����;������� ������;;;;�����;�������;������;" +
              ";;;;Next Week;Two Weeks Away;Three Weeks Away;Next Month;Beyond Next Month;");
      }
      return base.GetLocalizedString(id);
    }
  }

  internal class RussianEditorsLocalizer : Localizer
  {
    public override string GetLocalizedString(StringId id)
    {
      switch (id)
      {
        case StringId.Cancel:
          return LangTranslate.UiGetText("������");
        case StringId.InvalidValueText:
          return LangTranslate.UiGetText("�������� ��������");
        case StringId.CaptionError:
          return LangTranslate.UiGetText("������");
        case StringId.DataEmpty:
          return LangTranslate.UiGetText("�����");
        case StringId.DateEditClear:
          return LangTranslate.UiGetText("��������");
        case StringId.DateEditToday:
          return LangTranslate.UiGetText("�������");
        case StringId.CheckChecked:
          return LangTranslate.UiGetText("��");
        case StringId.CheckUnchecked:
          return LangTranslate.UiGetText("���");
        case StringId.PictureEditMenuCut:
          return LangTranslate.UiGetText("��������");
        case StringId.PictureEditMenuCopy:
          return LangTranslate.UiGetText("�����������");
        case StringId.PictureEditMenuPaste:
          return LangTranslate.UiGetText("��������");
        case StringId.PictureEditMenuDelete:
          return LangTranslate.UiGetText("�������");
        case StringId.PictureEditMenuLoad:
          return LangTranslate.UiGetText("���������");
        case StringId.PictureEditMenuSave:
          return LangTranslate.UiGetText("���������");
        case StringId.NavigatorTextStringFormat:
          return LangTranslate.UiGetText("������ {0} �� {1}");
      }
      return base.GetLocalizedString(id);
    }
  }

  internal class RussianBarLocalizer : BarLocalizer
  {
    // overriding the GetLocalizedString method
    public override string GetLocalizedString(BarString id)
    {
      switch (id)
      {
        case BarString.AddOrRemove:
          return "1";
        case BarString.CustomizeButton:
          return LangTranslate.UiGetText("���������...");
        case BarString.CustomizeWindowCaption:
          return LangTranslate.UiGetText("���������");
        case BarString.MenuAnimationFade:
          return "2";
        case BarString.MenuAnimationNone:
          return "3";
        case BarString.MenuAnimationRandom:
          return "4";
        case BarString.MenuAnimationSlide:
          return "5";
        case BarString.MenuAnimationSystem:
          return "6";
        case BarString.MenuAnimationUnfold:
          return "7";
        case BarString.NewToolbarCaption:
          return "8";
        case BarString.None:
          return "9";
        case BarString.RenameToolbarCaption:
          return "10";
        case BarString.ResetBar:
          return "11";
        case BarString.ResetBarCaption:
          return "12";
        case BarString.ResetButton:
          return LangTranslate.UiGetText("�����");
        case BarString.ToolBarMenu:
          return "14";
      }
      return base.GetLocalizedString(id);
    }
  }

  /*class RussianNavBarLocalizer : NavBarLocalizer
  {
    // overriding the GetLocalizedString method
    public override string GetLocalizedString(NavBarStringId id)
    {
      switch (id)
      {
        case NavBarStringId.NavPaneChevronHint: return "���������������� ������";
        case NavBarStringId.NavPaneMenuAddRemoveButtons: return "�������� ��� ������� ������";
        case NavBarStringId.NavPaneMenuShowMoreButtons: return "�������� ������ ������";
        case NavBarStringId.NavPaneMenuShowFewerButtons: return "�������� ������ ������";
      }
      return base.GetLocalizedString(id);
    }
  }*/

  // ��������� �������
  internal class KazakhGridLocalizer : GridLocalizer
  {
    // overriding the GetLocalizedString method
    public override string GetLocalizedString(GridStringId id)
    {
      switch (id)
      {
        case GridStringId.ColumnViewExceptionMessage:
          return "�� ������ ��������������� ��������?";
        case GridStringId.CustomFilterDialog2FieldCheck:
          return "2";
        case GridStringId.CustomFilterDialogCancelButton:
          return "������";
        case GridStringId.CustomFilterDialogCaption:
          return "�������� ������ ���:";
        //case  GridStringId.CustomFilterDialogConditionBlanks: return "�����";
        //case  GridStringId.CustomFilterDialogConditionEQU: return "�����";
        //case  GridStringId.CustomFilterDialogConditionGT: return "������ ���";
        //case  GridStringId.CustomFilterDialogConditionGTE: return "������ ��� �����";
        //case  GridStringId.CustomFilterDialogConditionLike: return "�������";
        //case  GridStringId.CustomFilterDialogConditionLT: return "������ ���";
        //case  GridStringId.CustomFilterDialogConditionLTE: return "������ ��� �����";
        //case  GridStringId.CustomFilterDialogConditionNEQ: return "�� �����";
        //case  GridStringId.CustomFilterDialogConditionNonBlanks: return "�� �����";
        //case  GridStringId.CustomFilterDialogConditionNotLike: return "�� �������";
        //case  GridStringId.CustomFilterDialogFormCaption: return "��������� �������";
        case GridStringId.CustomFilterDialogRadioAnd:
          return "�";
        case GridStringId.CustomFilterDialogRadioOr:
          return "���";
        case GridStringId.CustomizationBands:
          return "18";
        case GridStringId.CustomizationCaption:
          return "��������� �������";
        case GridStringId.CustomizationColumns:
          return "20";
        case GridStringId.FileIsNotFoundError:
          return "������: ���� �� ������";
        case GridStringId.MenuColumnBestFit:
          return "������ ������������";
        case GridStringId.MenuColumnBestFitAllColumns:
          return "������ ������������ (��� �������)";
        case GridStringId.MenuColumnClearFilter:
          return "������ ������";
        case GridStringId.MenuColumnColumnCustomization:
          return "��������� �������";
        case GridStringId.MenuColumnFilter:
          return "������";
        case GridStringId.MenuColumnGroup:
          return "����������� �� �������";
        case GridStringId.MenuColumnSortAscending:
          return "����������� �� �����������";
        case GridStringId.MenuColumnSortDescending:
          return "����������� �� ��������";
        case GridStringId.MenuColumnUnGroup:
          return "30";
        case GridStringId.MenuFooterAverage:
          return "�������";
        case GridStringId.MenuFooterAverageFormat:
          return "32";
        case GridStringId.MenuFooterCount:
          return "����������";
        case GridStringId.MenuFooterCountFormat:
          return "34";
        case GridStringId.MenuFooterMax:
          return "��������";
        case GridStringId.MenuFooterMaxFormat:
          return "36";
        case GridStringId.MenuFooterMin:
          return "�������";
        case GridStringId.MenuFooterMinFormat:
          return "38";
        case GridStringId.MenuFooterNone:
          return "�����";
        case GridStringId.MenuFooterSum:
          return "�����";
        case GridStringId.MenuFooterSumFormat:
          return "41";
        case GridStringId.MenuGroupPanelClearGrouping:
          return "������ �����������";
        case GridStringId.MenuGroupPanelFullCollapse:
          return "��������� ��������";
        case GridStringId.MenuGroupPanelFullExpand:
          return "���������� ��������";
        case GridStringId.PopupFilterAll:
          return "(���)";
        case GridStringId.PopupFilterBlanks:
          return "(������)";
        case GridStringId.PopupFilterCustom:
          return "(���������...)";
        case GridStringId.PopupFilterNonBlanks:
          return "(�� ������)";
        case GridStringId.PrintDesignerBandedView:
          return "49";
        case GridStringId.PrintDesignerBandHeader:
          return "50";
        case GridStringId.PrintDesignerCardView:
          return "51";
        case GridStringId.PrintDesignerGridView:
          return "52";
        case GridStringId.WindowErrorCaption:
          return "������";
        case GridStringId.MenuColumnGroupBox:
          return "������ �����������";
        case GridStringId.GridOutlookIntervals:
          return "������;������� �����;��� ������ �����;��� ������ �����;������� ������;;;;�����;�������;������; " +
                 ";;;;Next Week;Two Weeks Away;Three Weeks Away;Next Month;Beyond Next Month;";
      }
      return base.GetLocalizedString(id);
    }
  }

  internal class KazakhEditorsLocalizer : Localizer
  {
    public override string GetLocalizedString(StringId id)
    {
      switch (id)
      {
        case StringId.Cancel:
          return "������";
        case StringId.CaptionError:
          return "������";
        case StringId.DataEmpty:
          return "�����";
        case StringId.DateEditClear:
          return "��������";
        case StringId.DateEditToday:
          return "�������";
        case StringId.CheckChecked:
          return "��";
        case StringId.CheckUnchecked:
          return "���";
        case StringId.PictureEditMenuCut:
          return "��������";
        case StringId.PictureEditMenuCopy:
          return "�����������";
        case StringId.PictureEditMenuPaste:
          return "��������";
        case StringId.PictureEditMenuDelete:
          return "�������";
        case StringId.PictureEditMenuLoad:
          return "���������";
        case StringId.PictureEditMenuSave:
          return "���������";
      }
      return base.GetLocalizedString(id);
    }
  }

  internal class KazakhBarLocalizer : BarLocalizer
  {
    // overriding the GetLocalizedString method
    public override string GetLocalizedString(BarString id)
    {
      switch (id)
      {
        case BarString.AddOrRemove:
          return "1";
        case BarString.CustomizeButton:
          return "���������...";
        case BarString.CustomizeWindowCaption:
          return "���������";
        case BarString.MenuAnimationFade:
          return "2";
        case BarString.MenuAnimationNone:
          return "3";
        case BarString.MenuAnimationRandom:
          return "4";
        case BarString.MenuAnimationSlide:
          return "5";
        case BarString.MenuAnimationSystem:
          return "6";
        case BarString.MenuAnimationUnfold:
          return "7";
        case BarString.NewToolbarCaption:
          return "8";
        case BarString.None:
          return "9";
        case BarString.RenameToolbarCaption:
          return "10";
        case BarString.ResetBar:
          return "11";
        case BarString.ResetBarCaption:
          return "12";
        case BarString.ResetButton:
          return "�����";
        case BarString.ToolBarMenu:
          return "14";
      }
      return base.GetLocalizedString(id);
    }
  }

  /*class KazakhNavBarLocalizer : NavBarLocalizer
  {
    // overriding the GetLocalizedString method
    public override string GetLocalizedString(NavBarStringId id)
    {
      switch (id)
      {
        case NavBarStringId.NavPaneChevronHint: return "���������������� ������";
        case NavBarStringId.NavPaneMenuAddRemoveButtons: return "�������� ��� ������� ������";
        case NavBarStringId.NavPaneMenuShowMoreButtons: return "�������� ������ ������";
        case NavBarStringId.NavPaneMenuShowFewerButtons: return "�������� ������ ������";
      }
      return base.GetLocalizedString(id);
    }
  }*/
}