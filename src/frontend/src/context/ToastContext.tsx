/* eslint-disable react-hooks/exhaustive-deps */
/* eslint-disable react/jsx-no-constructed-context-values */
import React, {
  createContext,
  useCallback,
  useState,
  useContext,
  useRef,
  ReactNode,
} from "react";
import { Toast } from "primereact/toast";
import IToastModelContext from "../interfaces/IToastModelContext";

const ToastContext = createContext<IToastModelContext>(
  {} as IToastModelContext,
);

type toastPositions = "top-right" | "top-left" | "bottom-left" | "bottom-right";
type severitys = "success" | "info" | "warn" | "error";

const ToastProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const toast = useRef<any>(null);
  const [toastPosition, setToastPosition] =
    useState<toastPositions>("top-right");

  const clearCurrent = useCallback(() => {
    toast.current.clear();
    return true;
  }, []);

  const displayToast = useCallback(
    (
      severity: severitys,
      title: string,
      message: string,
      sticky: boolean = true,
      duration: number = 3000,
      toastPosition: toastPositions = "top-right",
    ) => {
      setToastPosition(toastPosition);
      toast.current.show({
        severity,
        summary: title,
        detail: addNewlines(message),
        life: duration,
        sticky,
      });
      return true;
    },
    [],
  );

  const addNewlines = (string: any): string => {
    const lines: any = [];
    let currentLine = "";

    // Split the string into words
    const words = string.split(" ");

    // Loop through each word
    for (let i = 0; i < words.length; i++) {
      let word = words[i];

      // If the word is too long, cut it
      if (word.length > 43) {
        word = word.slice(0, 43);
      }

      // If adding the word to the current line would make it too long, start a new line
      if (currentLine.length + word.length > 43) {
        lines.push(currentLine.trim());
        currentLine = "";
      }

      // Add the word to the current line
      currentLine += `${word} `;

      // If the current line is too long and there is a space, remove the space and start a new line
      if (
        currentLine.trim().length > 43 &&
        currentLine.lastIndexOf(" ") !== -1
      ) {
        currentLine = `${currentLine.slice(0, currentLine.lastIndexOf(" "))}\n`;
        lines.push(currentLine.trim());
        currentLine = "";
      }
    }

    // Add the last line
    lines.push(currentLine.trim());

    return lines?.join("\n");
  };

  return (
    <ToastContext.Provider value={{ displayToast, clearCurrent }}>
      {children}
      <Toast position={toastPosition} ref={toast} />
    </ToastContext.Provider>
  );
};

function useToast(): IToastModelContext {
  const context = useContext(ToastContext);
  if (!context) {
    throw new Error("ToastContext must be used within an AuthProvider");
  }
  return context;
}
export { ToastProvider, useToast };
