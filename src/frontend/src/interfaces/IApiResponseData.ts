interface IApiResponseData {
  message: string;
  data: {};
  error?: {};
  technicalObservation?: {};
  success: boolean;
  translationKey?: string;
}

export default IApiResponseData;
