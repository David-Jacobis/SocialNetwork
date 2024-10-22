// import IApiResponse from "../interfaces/IApiResponse";
import IApiResponseModel from "../interfaces/IApiResponseModel";

export const validateResponseObject = (
  responseData: any,
): IApiResponseModel => {
  const response: IApiResponseModel = handleApiResponse(responseData);
  response.successMessages = response.successMessages.filter(
    (item, index) =>
      response.successMessages.indexOf(item) === index && item.length > 0,
  );
  response.errors = response.errors.filter(
    (item, index) => response.errors.indexOf(item) === index && item.length > 0,
  );

  return response;
};

const handleApiResponse = (responseData: any): IApiResponseModel => {
  const response: IApiResponseModel = {
    errors: [],
    success: false,
    data: null,
    translationResponse: null,
    successMessages: [],
    statusCode: null,
  };
  response.statusCode =
    responseData?.response?.status || responseData?.status || null;

  if (responseData?.response?.status === 200 || responseData.status === 200) {
    response.success = true;

    response.data = responseData?.data?.data || null;

    if (
      typeof responseData?.data?.translationKey === "string" &&
      responseData?.data?.translationKey.length > 0
    ) {
      response.successMessages.push(responseData?.data?.translationKey);
    }

    if (
      typeof responseData?.data?.message === "string" &&
      responseData?.data?.message.length > 0
    ) {
      response.successMessages.push(responseData?.data?.message);
    }

    if (
      typeof responseData?.data?.data === "string" &&
      responseData?.data?.data.length > 0
    ) {
      response.successMessages.push(responseData?.data?.data);
    }

    return response;
  } else {
    response.success = false;
    response.data = responseData?.response?.data || null;
    const errorData: any = responseData?.response?.data?.error;

    if (Array.isArray(errorData)) {
      errorData.forEach((item: any) => {
        response.errors.push(item);
      });
    }

    if (
      typeof response?.data?.message === "string" &&
      response?.data?.message.length > 0
    ) {
      response.errors.push(response?.data?.message);
      return response;
    }

    if (errorData?.Message) {
      response.errors.push(errorData?.Message);
    }

    if (response.errors.length > 0) {
      return response;
    }

    if (responseData?.response?.data?.translationKey !== undefined) {
      response.errors.push(responseData?.response?.data?.translationKey);
    }

    if (response.errors.length > 0) {
      return response;
    }

    if (typeof responseData?.response?.data?.data === "string") {
      response.errors.push(responseData?.response?.data?.data);
    }

    if (typeof responseData?.data === "string") {
      response.errors.push(responseData.data);
    }

    if (typeof responseData?.Error === "string") {
      response.errors.push(responseData.data);
    }

    if (responseData?.message?.length > 0) {
      response.errors.push(responseData?.message);
    }
  }

  return response;
};
