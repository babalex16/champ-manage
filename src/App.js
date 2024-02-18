import "bootstrap/dist/css/bootstrap.min.css";

import { Route, Routes } from "react-router-dom";

import CustomNavbar from "./components/Navbar/CustomNavbar";
import FrontPage from "./pages/FrontPage";

import NewsPage from "./pages/news/NewsPage";
import RulesPage from "./pages/RulesPage";
import ContactsPage from "./pages/ContactsPage";
import Acc from "./pages/AccountPage";
import RegistrationPage from "./pages/RegistrationPage";
import TimerPage from "./pages/TimerPage";
import TestPage from "./pages/TestPage";

import { NewsProvider } from "./context/newsContext";
import { ChampionshipProvider } from "./context/championshipContext";
import NewsTemplate from "./pages/news/newsPage/NewsTemplate";
import ChampionshipsPage from "./pages/championship/ChamoionshipsPage";
import ChampionshipTemplate from "./pages/championship/ChampionshipTemplate";



function App() {
  return (
    <NewsProvider>
      <ChampionshipProvider>
        <>
          <header>
            <CustomNavbar />
          </header>
          <Routes>
            <Route path="/" element={<FrontPage />} />
            <Route path="/championships" element={<ChampionshipsPage />} />
            <Route path="/championship/:id" element={<ChampionshipTemplate />} />
            {/* <Route path="/news" element={<NewsPage />} /> */}
            {/* <Route path="/newsPage/:id" element={<NewsTemplate/>} /> */}
            <Route path="/rules" element={<RulesPage />} />
            <Route path="/contacts" element={<ContactsPage />} />
            <Route path="/account" element={<Acc />} />
            <Route path="/register" element={<RegistrationPage />} />
            <Route path="/timer" element={<TimerPage />} />
            <Route path="/test" element={<TestPage />} />
          </Routes>
        </>
      </ChampionshipProvider>
    </NewsProvider>
  );
}

export default App;
