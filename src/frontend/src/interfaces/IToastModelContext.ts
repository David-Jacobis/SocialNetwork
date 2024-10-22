type toastPositions = "top-right" | "top-left" | "bottom-left" | "bottom-right";
type severitys = "success" | "info" | "warn" | "error";

interface IToastModelContext {
  displayToast(
    severity: severitys,
    title: string,
    message: string,
    sticky?: boolean,
    duration?: number,
    toastPosition?: toastPositions,
  ): void;
  clearCurrent(): void;
}

export default IToastModelContext;
