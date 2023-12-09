import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import Image from "react-bootstrap/Image";

import Tab from "react-bootstrap/Tab";
import Tabs from "react-bootstrap/Tabs";

import { useChampionships } from "../../context/championshipContext";

import apiService from "../../services/apiService";

import Footer from "../../components/Footer/Footer";
import Information from "../../components/Tabs/Information/Information";
import ListOfParticipants from "../../components/Tabs/List-of-Participants/List-of-Participants";
import Brackets from "../../components/Tabs/Brackets/Brackets";
import Results from "../../components/Tabs/Results/Results";
import coverImg from "../../assets/photos/bg-mustard-color.jpg";

import "../../utils/championshipTemplate.css";

const ChampionshipTemplate = () => {
  const { championships } = useChampionships();
  const { id } = useParams();
  const [championship, setChampionship] = useState({});

  useEffect(() => {
    const fetchData = async () => {
      try {
        if (championships.length === 0) {
          const fetchedChampionship = await apiService.getChampionships();
          setChampionship(
            fetchedChampionship.find(
              (_element, index) => index === parseInt(id, 10)
            )
          );
        } else {
          setChampionship(
            championships.find((_element, index) => index === parseInt(id, 10))
          );
        }
      } catch (error) {
        console.log("Error fetching posts:", error);
      }
    };

    fetchData();
  }, [championships, id]);

  return (
    <div
      style={{
        paddingTop: "75px",
        backgroundColor: "#5c8374",
        minHeight: "100vh",
      }}
    >
      <Image src={coverImg} fluid className="event-banner" />
      <div className="event-data mx-auto">
        <Tabs
          defaultActiveKey="information"
          id="event-tabs"
          className="mb-5"
          fill
        >
          <Tab eventKey="information" title="Information">
            <Information championship={championship} />
          </Tab>

          <Tab eventKey="participants" title="List of Participants">
            <ListOfParticipants props={championship} />
          </Tab>

          <Tab eventKey="brackets" title="Brackets">
            <Brackets props={championship} />
          </Tab>

          <Tab eventKey="results" title="Results">
            <Results />
          </Tab>
        </Tabs>
        <Footer />
      </div>
    </div>
  );
};

export default ChampionshipTemplate;
