import axios from "axios";
import i18n from "i18next";
// import { isAuthenticated, getToken, logout } from "../Auth";
import { translateLanguagesList } from "../../utilities/util";
import {validateResponseObject} from "../../utilities/validateApiResponse";

const ApiHandler = (baseURL: string): any => {
  const translateName = translateLanguagesList().find(
    (item: any) => item.code === i18n.language,
  ).name;

  const api = axios.create({
    baseURL: `${baseURL}/${translateName}/api/`,
    responseType: `json`,
  });

//   api.interceptors.request.use(
//     (config: any) => {
//       if (isAuthenticated() === true) {
//         const token = getToken();
//         if (token) {
//           config.headers.Authorization = `Bearer ${token}`;
//         }
//         return config;
//       }
//       return new Promise(() => {
//         logout();
//       });
//     },
//     (error) => {
//       return Promise.reject(error);
//     },
//   );

  api.interceptors.response.use(
    (response) => {

      let returnData: any = validateResponseObject(response)
      return returnData
    },
    (error) => {

      let returnData: any = validateResponseObject(error)
      return Promise.reject(returnData);
    },
  );

  return api;
};

export default ApiHandler;
