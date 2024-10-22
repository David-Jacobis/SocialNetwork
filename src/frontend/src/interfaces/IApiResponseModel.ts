import IApiResponseData from "./IApiResponseData";

interface IApiResponseModel {
  errors: string[];
  success: boolean;
  data?: IApiResponseData | string | null | any;
  translationResponse?: string | null;
  successMessages: string[];
  statusCode?: number | null;
}

export default IApiResponseModel;
