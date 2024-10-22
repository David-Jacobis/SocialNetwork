import { getUrlApi } from '../utilities/util';
import ApiHandler from './ApiHandlers/ApiHandler';



export const baseURL = String(getUrlApi());

export default class DefaultApi {
    static async callEndPoint(): Promise<any> {
        return ApiHandler(baseURL).post("teste/create");
    };
    
}
