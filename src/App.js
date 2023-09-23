import 'bootstrap/dist/css/bootstrap.min.css';
import CustomNavbar from './components/Navbar/CustomNavbar';
import FrontPage from './pages/FrontPage'
import EventsPage from './pages/EventsPage'
import NewsPage from './pages/NewsPage'
import RulesPage from './pages/RulesPage'
import ContactsPage from './pages/ContactsPage'
import AccountPage from './pages/AccountPage';
import RegistrationPage from './pages/RegistrationPage';
import { Route, Routes } from 'react-router-dom';

function App() {
  return (
    <>
        <header>
          <CustomNavbar/>
        </header>
        <Routes>
          <Route path='/' element={<FrontPage/>} />
          <Route path='/events' element={<EventsPage/>} />
          <Route path='/news' element={<NewsPage/>} />
          <Route path='/rules' element={<RulesPage/>} />
          <Route path='/contacts' element={<ContactsPage/>} />
          <Route path='/account' element={<AccountPage/>} />
          <Route path='/register'element={<RegistrationPage/>} />
        </Routes>
    </>
  );
}

export default App;
