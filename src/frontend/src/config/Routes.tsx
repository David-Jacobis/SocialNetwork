import React from "react";
import Home from "../pages/Home";
import User from "../pages/User";
import NotFound from "../pages/404";
import  AppLayout  from "../layouts/main-layout/Index";


import { Routes, Route } from "react-router-dom";


const AppRoutes: React.FC = () => (
  <Routes>
    <Route path="/*" element={<NotFound />} />
    <Route element={<AppLayout />}>
      <Route path="/" element={<Home />} />
      <Route path="/home" element={<Home />} />
      <Route path="/users" element={<User />} />
    </Route>
  </Routes>
);
export default AppRoutes;
