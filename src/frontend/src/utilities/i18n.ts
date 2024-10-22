import i18n from "i18next";
import { initReactI18next } from "react-i18next";
import Backend from "i18next-xhr-backend";
import LanguageDetector from "i18next-browser-languagedetector";

const fallbackLng = navigator.language.substring(0, 2);
const availableLanguages = ["pt", "en"];

const options = {
  fallbackLng, // if user computer language is not on the list of available languages, than we will be using the fallback language specified earlier
  debug: false,
  lng: fallbackLng,
  whitelist: availableLanguages,
  interpolation: {
    escapeValue: false,
  },
  appendNamespaceToMissingKey: true,
  backend: {
    loadPath: "/locales/{{lng}}/{{ns}}.json",
  },
};

i18n
  .use(Backend) // load translation using xhr -> see /public/locales. We will add locales in the next step
  .use(LanguageDetector) // detect user language
  .use(initReactI18next) // pass the i18n instance to react-i18next.
  .init(options);

export default i18n;
