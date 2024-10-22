import React from "react";
import "./App.css";
import { BrowserRouter } from "react-router-dom";

import RoutesApp from "./config/Routes";
// import { AuthProvider } from "./context/AuthContext";
import { ToastProvider } from "./context/ToastContext";



const App: React.FC = () => (
  <BrowserRouter>
    <ToastProvider>
      {/* <AuthProvider> */}
        <RoutesApp />
      {/* </AuthProvider> */}
    </ToastProvider>
  </BrowserRouter>
);

export default App;
