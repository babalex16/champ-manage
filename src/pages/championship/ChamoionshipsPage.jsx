import React from "react";

import Championships from "../../components/Championships/Championships";
import Footer from "../../components/Footer/Footer";

const ChampionshipsPage = () => {
  return (
    <div
      style={{
        paddingTop: "80px",
        backgroundColor: "#183D3D",
        minHeight: "100vh",
      }}
    >
      <Championships />
      <Footer backgroundColor="#183D3D" />
    </div>
  );
};

export default ChampionshipsPage;
