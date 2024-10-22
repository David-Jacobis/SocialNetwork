import React, { useEffect } from "react";
import { Button } from "primereact/button";
// import { useNavigate } from 'react-router-dom';
import styled from "./Index.module.css";
// import logo from "../../assets/img/replyWide.png";

const NotFound: React.FC = () => {
  // const navigate = useNavigate();

  useEffect(() => {
    // navigate('/home', {replace: true});
  }, []);

  return (
    <div className={`grid col-12 align-content-center flex-column mt-7 `}>
      {/* <img src={logo} alt="" /> */}
      <h1 className={`${styled.header_tittle} `}>Sorry, Page Not Found</h1>
      <p className={`${styled.text} `}>
        The page you are looking for does not exist.
      </p>
      <Button
        className={`${styled.button} `}
        onClick={() => window.history.back()}
      >
        Go Back
      </Button>
    </div>
  );
};

export default NotFound;
