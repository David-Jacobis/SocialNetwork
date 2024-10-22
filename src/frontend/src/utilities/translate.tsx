import { locale } from "primereact/api";
import translate from "./i18n";
import './primeReactDefaultTranslations'

export const changeUserLanguage = async (language: any): Promise<void> => {
  locale(language);
  await translate.changeLanguage(language);
};
