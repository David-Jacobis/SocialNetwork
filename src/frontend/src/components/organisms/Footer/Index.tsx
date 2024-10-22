/* eslint-disable react-hooks/exhaustive-deps */
import React from "react";
import { Toolbar } from "primereact/toolbar";
import styled from "./Index.module.css";

const Footer: React.FC = () => {
  const rightContents = (
    <div className="grid">
      <div className="col-12">Stellantis</div>
    </div>
  );

  const leftContents = (
    <div className="grid">
      <div className="col-12">Stellantis</div>
    </div>
  );
  return (
    <Toolbar
      start={leftContents}
      end={rightContents}
      className={`${styled.footer_div}`}
    />
  );
};
export default Footer;
