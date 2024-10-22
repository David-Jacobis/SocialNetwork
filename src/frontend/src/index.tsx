import React from "react";
import { createRoot } from "react-dom/client";
import reportWebVitals from "./reportWebVitals";
// import ReactDOM from 'react-dom';
import "./index.css";
import "./config/Styles";
// import './config/Scripts';

import App from "./App";

reportWebVitals();

const root = createRoot(document.getElementById("root") as HTMLDivElement);
if (root === null) throw new Error("Root container missing in index.html");

root.render(
  <React.Suspense fallback="">
      <App />
  </React.Suspense>,
);
