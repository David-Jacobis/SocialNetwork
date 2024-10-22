import React from "react";

//import IHeader from "../../interfaces/IHeader";
//import NavigationHeader from "../../components/NavigationHeader";
import styled from "./Index.module.css";

const Home: React.FC = () => {
  return (
    <>
      <div>
          <div className={`${styled.row} p-fluid`}>

            <div className={styled.homeContainer}>

              <div className={styled.homeFlex}>
                <h1>Stellantis</h1>
                <span>MAP - Motor Ativo Problemático</span>
              </div>

            </div>

          </div>
        </div>
      </>
  );
};

export default Home;
