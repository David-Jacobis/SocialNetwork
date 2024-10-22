import IApiResponseData from "./IApiResponseData";
import IFluentValidationError from "./IFluentValidationError";

interface IApiResponse {
  code: string;
  config: object;
  message: string;
  name: string;
  request: object | null;
  response: {
    config: object | null;
    data: IApiResponseData | null;
    headers: object | null;
    request: object | null;
    status: number | null;
    statusTest: string | null;
  } | null;
  data: IApiResponseData | any | string | null;
  headers: object;
  status: number;
  statusText: string;
  Error: IFluentValidationError[] | null;
  TechnicalObservation: object | null;
  sucess: boolean | null;
}

export default IApiResponse;
