import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useNews } from "../../../context/newsContext";

import Footer from "../../../components/Footer/Footer";

import apiService from "../../../services/apiService";

import newsImages from "../../../assets/newsPosts";
import "./newsTemplate.css";
import { Image } from "react-bootstrap";

const NewsTemplate = () => {
  const { news } = useNews();
  const { id } = useParams();
  const [post, setPost] = useState({});

  useEffect(() => {
    const fetchData = async () => {
      try {
        if (news.length === 0) {
          const fetchedNews = await apiService.getPosts();
          setPost(
            fetchedNews.find((_element, index) => index === parseInt(id, 10))
          );
        } else {
          setPost(news.find((_element, index) => index === parseInt(id, 10)));
        }
      } catch (error) {
        console.error("Error fetching posts:", error);
      }
    };

    fetchData();
  }, [news, id]);

  return (
    <>
      <div
        style={{
          paddingTop: "75px",
          backgroundColor: "#5c8374",
          minHeight: "100vh",
        }}
      >
        <div className="news-article-container">
          <Image
            fluid
            style={{ width: '70%', height: '50%' }}
            src={newsImages[id]}
            alt="Article"
          />
          <h1 className="article-title">{post.title}</h1>
          <p className="article-date">
            <strong>{post.dateOfArticle}</strong>
          </p>
          <p className="article-content">{post.text}</p>
        </div>
        <Footer />
      </div>
    </>
  );
};

export default NewsTemplate;
