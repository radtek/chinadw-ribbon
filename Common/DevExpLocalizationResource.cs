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

  // Русские ресурсы
  internal class RussianGridLocalizer : GridLocalizer
  {
    // overriding the GetLocalizedString method
    public override string GetLocalizedString(GridStringId id)
    {
      switch (id)
      {
        case GridStringId.GridGroupPanelText:
          return LangTranslate.UiGetText("Поместите сюда заголовок колонки, чтобы сгруппировать по данной колонке");
        case GridStringId.ColumnViewExceptionMessage:
          return LangTranslate.UiGetText("Вы хотите скорректировать значение?");
        case GridStringId.CustomFilterDialog2FieldCheck:
          return "2";
        case GridStringId.CustomFilterDialogCancelButton:
          return LangTranslate.UiGetText("Отмена");
        case GridStringId.CustomFilterDialogCaption:
          return LangTranslate.UiGetText("Показать строки где:");
        //case  GridStringId.CustomFilterDialogConditionBlanks: return LangTranslate.UIGetText("пусто");
        //case  GridStringId.CustomFilterDialogConditionEQU: return LangTranslate.UIGetText("равно");
        //case  GridStringId.CustomFilterDialogConditionGT: return LangTranslate.UIGetText("больше чем");
        //case  GridStringId.CustomFilterDialogConditionGTE: return LangTranslate.UIGetText("больше или равно");
        //case  GridStringId.CustomFilterDialogConditionLike: return LangTranslate.UIGetText("подобно");
        //case  GridStringId.CustomFilterDialogConditionLT: return LangTranslate.UIGetText("меньше чем");
        //case  GridStringId.CustomFilterDialogConditionLTE: return LangTranslate.UIGetText("меньше или равно");
        //case  GridStringId.CustomFilterDialogConditionNEQ: return LangTranslate.UIGetText("не равно");
        //case  GridStringId.CustomFilterDialogConditionNonBlanks: return LangTranslate.UIGetText("не пусто");
        //case  GridStringId.CustomFilterDialogConditionNotLike: return LangTranslate.UIGetText("не подобно");
        case GridStringId.CustomFilterDialogFormCaption:
          return LangTranslate.UiGetText("Настройка фильтра");
        case GridStringId.CustomFilterDialogRadioAnd:
          return LangTranslate.UiGetText("И");
        case GridStringId.CustomFilterDialogRadioOr:
          return LangTranslate.UiGetText("ИЛИ");
        case GridStringId.CustomizationBands:
          return "18";
        case GridStringId.CustomizationCaption:
          return LangTranslate.UiGetText("Настройка колонок");
        case GridStringId.CustomizationColumns:
          return "20";
        case GridStringId.FileIsNotFoundError:
          return LangTranslate.UiGetText("Ошибка: Файл не найден");
        case GridStringId.MenuColumnBestFit:
          return LangTranslate.UiGetText("Лучшее расположение");
        case GridStringId.MenuColumnBestFitAllColumns:
          return LangTranslate.UiGetText("Лучшее расположение (все колонки)");
        case GridStringId.MenuColumnClearFilter:
          return LangTranslate.UiGetText("Убрать фильтр");
        case GridStringId.MenuColumnColumnCustomization:
          return LangTranslate.UiGetText("Настройка колонок");
        case GridStringId.MenuColumnFilter:
          return LangTranslate.UiGetText("Фильтр");
        case GridStringId.MenuColumnGroup:
          return LangTranslate.UiGetText("Группировка по колонке");
        case GridStringId.MenuColumnSortAscending:
          return LangTranslate.UiGetText("Сортировать По Возрастанию");
        case GridStringId.MenuColumnSortDescending:
          return LangTranslate.UiGetText("Сортировать По Убыванию");
        case GridStringId.MenuColumnUnGroup:
          return "30";
        case GridStringId.MenuFooterAverage:
          return LangTranslate.UiGetText("Среднее");
        case GridStringId.MenuFooterAverageFormat:
          return "32";
        case GridStringId.MenuFooterCount:
          return LangTranslate.UiGetText("Количество");
        case GridStringId.MenuFooterCountFormat:
          return "34";
        case GridStringId.MenuFooterMax:
          return LangTranslate.UiGetText("Максимум");
        case GridStringId.MenuFooterMaxFormat:
          return "36";
        case GridStringId.MenuFooterMin:
          return LangTranslate.UiGetText("Минимум");
        case GridStringId.MenuFooterMinFormat:
          return "38";
        case GridStringId.MenuFooterNone:
          return LangTranslate.UiGetText("Пусто");
        case GridStringId.MenuFooterSum:
          return LangTranslate.UiGetText("Сумма");
        case GridStringId.MenuFooterSumFormat:
          return "41";
        case GridStringId.MenuGroupPanelClearGrouping:
          return LangTranslate.UiGetText("Убрать группировку");
        case GridStringId.MenuGroupPanelFullCollapse:
          return LangTranslate.UiGetText("Полностью свернуть");
        case GridStringId.MenuGroupPanelFullExpand:
          return LangTranslate.UiGetText("Польностью раскрыть");
        case GridStringId.PopupFilterAll:
          return LangTranslate.UiGetText("(Все)");
        case GridStringId.PopupFilterBlanks:
          return LangTranslate.UiGetText("(Пустые)");
        case GridStringId.PopupFilterCustom:
          return LangTranslate.UiGetText("(Настройка...)");
        case GridStringId.PopupFilterNonBlanks:
          return LangTranslate.UiGetText("(Не пустые)");
        case GridStringId.PrintDesignerBandedView:
          return "49";
        case GridStringId.PrintDesignerBandHeader:
          return "50";
        case GridStringId.PrintDesignerCardView:
          return "51";
        case GridStringId.PrintDesignerGridView:
          return "52";
        case GridStringId.WindowErrorCaption:
          return LangTranslate.UiGetText("Ошибка");
        case GridStringId.MenuColumnGroupBox:
          return LangTranslate.UiGetText("Панель группировки");
        case GridStringId.GridNewRowText:
          return LangTranslate.UiGetText("Нажмите здесь, чтобы добавить данные");
        case GridStringId.GridOutlookIntervals:
          return
            LangTranslate.UiGetText(
              "Старее;Прошлый месяц;Три недели назад;Две недели назад;Прошлая неделя;;;;Вчера;Сегодня;Завтра;" +
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
          return LangTranslate.UiGetText("Отмена");
        case StringId.InvalidValueText:
          return LangTranslate.UiGetText("Неверное значение");
        case StringId.CaptionError:
          return LangTranslate.UiGetText("Ошибка");
        case StringId.DataEmpty:
          return LangTranslate.UiGetText("Пусто");
        case StringId.DateEditClear:
          return LangTranslate.UiGetText("Очистить");
        case StringId.DateEditToday:
          return LangTranslate.UiGetText("Сегодня");
        case StringId.CheckChecked:
          return LangTranslate.UiGetText("Да");
        case StringId.CheckUnchecked:
          return LangTranslate.UiGetText("Нет");
        case StringId.PictureEditMenuCut:
          return LangTranslate.UiGetText("Вырезать");
        case StringId.PictureEditMenuCopy:
          return LangTranslate.UiGetText("Скопировать");
        case StringId.PictureEditMenuPaste:
          return LangTranslate.UiGetText("Вставить");
        case StringId.PictureEditMenuDelete:
          return LangTranslate.UiGetText("Удалить");
        case StringId.PictureEditMenuLoad:
          return LangTranslate.UiGetText("Загрузить");
        case StringId.PictureEditMenuSave:
          return LangTranslate.UiGetText("Сохранить");
        case StringId.NavigatorTextStringFormat:
          return LangTranslate.UiGetText("Запись {0} из {1}");
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
          return LangTranslate.UiGetText("Настройка...");
        case BarString.CustomizeWindowCaption:
          return LangTranslate.UiGetText("Настройка");
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
          return LangTranslate.UiGetText("Сброс");
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
        case NavBarStringId.NavPaneChevronHint: return "Конфигурирование кнопок";
        case NavBarStringId.NavPaneMenuAddRemoveButtons: return "Добавить или удалить кнопки";
        case NavBarStringId.NavPaneMenuShowMoreButtons: return "Показать больше кнопок";
        case NavBarStringId.NavPaneMenuShowFewerButtons: return "Показать меньше кнопок";
      }
      return base.GetLocalizedString(id);
    }
  }*/

  // Казахские ресурсы
  internal class KazakhGridLocalizer : GridLocalizer
  {
    // overriding the GetLocalizedString method
    public override string GetLocalizedString(GridStringId id)
    {
      switch (id)
      {
        case GridStringId.ColumnViewExceptionMessage:
          return "Вы хотите скорректировать значение?";
        case GridStringId.CustomFilterDialog2FieldCheck:
          return "2";
        case GridStringId.CustomFilterDialogCancelButton:
          return "Отмена";
        case GridStringId.CustomFilterDialogCaption:
          return "Показать строки где:";
        //case  GridStringId.CustomFilterDialogConditionBlanks: return "пусто";
        //case  GridStringId.CustomFilterDialogConditionEQU: return "равно";
        //case  GridStringId.CustomFilterDialogConditionGT: return "больше чем";
        //case  GridStringId.CustomFilterDialogConditionGTE: return "больше или равно";
        //case  GridStringId.CustomFilterDialogConditionLike: return "подобно";
        //case  GridStringId.CustomFilterDialogConditionLT: return "меньше чем";
        //case  GridStringId.CustomFilterDialogConditionLTE: return "меньше или равно";
        //case  GridStringId.CustomFilterDialogConditionNEQ: return "не равно";
        //case  GridStringId.CustomFilterDialogConditionNonBlanks: return "не пусто";
        //case  GridStringId.CustomFilterDialogConditionNotLike: return "не подобно";
        //case  GridStringId.CustomFilterDialogFormCaption: return "Настройка фильтра";
        case GridStringId.CustomFilterDialogRadioAnd:
          return "И";
        case GridStringId.CustomFilterDialogRadioOr:
          return "ИЛИ";
        case GridStringId.CustomizationBands:
          return "18";
        case GridStringId.CustomizationCaption:
          return "Настройка колонок";
        case GridStringId.CustomizationColumns:
          return "20";
        case GridStringId.FileIsNotFoundError:
          return "Ошибка: Файл не найден";
        case GridStringId.MenuColumnBestFit:
          return "Лучшее расположение";
        case GridStringId.MenuColumnBestFitAllColumns:
          return "Лучшее расположение (все колонки)";
        case GridStringId.MenuColumnClearFilter:
          return "Убрать фильтр";
        case GridStringId.MenuColumnColumnCustomization:
          return "Настройка колонок";
        case GridStringId.MenuColumnFilter:
          return "Фильтр";
        case GridStringId.MenuColumnGroup:
          return "Группировка по колонке";
        case GridStringId.MenuColumnSortAscending:
          return "Сортировать По Возрастанию";
        case GridStringId.MenuColumnSortDescending:
          return "Сортировать По Убыванию";
        case GridStringId.MenuColumnUnGroup:
          return "30";
        case GridStringId.MenuFooterAverage:
          return "Среднее";
        case GridStringId.MenuFooterAverageFormat:
          return "32";
        case GridStringId.MenuFooterCount:
          return "Количество";
        case GridStringId.MenuFooterCountFormat:
          return "34";
        case GridStringId.MenuFooterMax:
          return "Максимум";
        case GridStringId.MenuFooterMaxFormat:
          return "36";
        case GridStringId.MenuFooterMin:
          return "Минимум";
        case GridStringId.MenuFooterMinFormat:
          return "38";
        case GridStringId.MenuFooterNone:
          return "Ничто";
        case GridStringId.MenuFooterSum:
          return "Сумма";
        case GridStringId.MenuFooterSumFormat:
          return "41";
        case GridStringId.MenuGroupPanelClearGrouping:
          return "Убрать группировку";
        case GridStringId.MenuGroupPanelFullCollapse:
          return "Полностью свернуть";
        case GridStringId.MenuGroupPanelFullExpand:
          return "Польностью раскрыть";
        case GridStringId.PopupFilterAll:
          return "(Все)";
        case GridStringId.PopupFilterBlanks:
          return "(Пустые)";
        case GridStringId.PopupFilterCustom:
          return "(Настройка...)";
        case GridStringId.PopupFilterNonBlanks:
          return "(Не пустые)";
        case GridStringId.PrintDesignerBandedView:
          return "49";
        case GridStringId.PrintDesignerBandHeader:
          return "50";
        case GridStringId.PrintDesignerCardView:
          return "51";
        case GridStringId.PrintDesignerGridView:
          return "52";
        case GridStringId.WindowErrorCaption:
          return "Ошибка";
        case GridStringId.MenuColumnGroupBox:
          return "Панель группировки";
        case GridStringId.GridOutlookIntervals:
          return "Старее;Прошлый месяц;Три недели назад;Две недели назад;Прошлая неделя;;;;Вчера;Сегодня;Завтра; " +
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
          return "Отмена";
        case StringId.CaptionError:
          return "Ошибка";
        case StringId.DataEmpty:
          return "Пусто";
        case StringId.DateEditClear:
          return "Очистить";
        case StringId.DateEditToday:
          return "Сегодня";
        case StringId.CheckChecked:
          return "Да";
        case StringId.CheckUnchecked:
          return "Нет";
        case StringId.PictureEditMenuCut:
          return "Вырезать";
        case StringId.PictureEditMenuCopy:
          return "Скопировать";
        case StringId.PictureEditMenuPaste:
          return "Вставить";
        case StringId.PictureEditMenuDelete:
          return "Удалить";
        case StringId.PictureEditMenuLoad:
          return "Загрузить";
        case StringId.PictureEditMenuSave:
          return "Сохранить";
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
          return "Настройка...";
        case BarString.CustomizeWindowCaption:
          return "Настройка";
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
          return "Сброс";
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
        case NavBarStringId.NavPaneChevronHint: return "Конфигурирование кнопок";
        case NavBarStringId.NavPaneMenuAddRemoveButtons: return "Добавить или удалить кнопки";
        case NavBarStringId.NavPaneMenuShowMoreButtons: return "Показать больше кнопок";
        case NavBarStringId.NavPaneMenuShowFewerButtons: return "Показать меньше кнопок";
      }
      return base.GetLocalizedString(id);
    }
  }*/
}