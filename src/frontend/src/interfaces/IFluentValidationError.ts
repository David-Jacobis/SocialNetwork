interface IFluentValidationError {
  propertyName: string;
  errorMessage: string;
  attemptedValue: null | any;
  customState: null | any;
  severity: number;
  errorCode: string;
  // formattedMessagePlaceholderValues: {
  //     PropertyName: Code ,
  //     PropertyValue: null
  // }
  formattedMessagePlaceholderValues: any;
}

export default IFluentValidationError;
