export const checkIsProd = (): boolean =>{
  return process.env.REACT_APP_ENV ? process.env.REACT_APP_ENV === "PROD" : false
}

export const TOKEN_KEY = "TOKEN_KEY"
export const TOKEN_IDENTIFICATION = "TOKEN_IDENTIFICATION"

export const getUrlApi = (): any =>
  checkIsProd()
    ? process.env.REACT_APP_API_URL
    : process.env.REACT_APP_API_URL;


export const translateLanguagesList = (): any[] => {
  return [
    { name: "pt-br", code: "pt" },
    { name: "en-us", code: "en" },
    { name: "es-ar", code: "es" },
    { name: "it-it", code: "it" },
    { name: "pt-br", code: "fr" },
  ];
};
