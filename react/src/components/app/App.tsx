import React from "react";
import { Login } from "../registerAndLogin/Login";
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import HomePage from "../homepage/HomePage";
import { Layout } from "../layout/Layout";
import { Register } from "../registerAndLogin/Register";
import { PlayerList } from "../playerList/PlayerList";
import { Office } from "../office/Office";
import { Profile } from "../office/profile/Profile";
import { StartPage } from "../startPage/StartPage";
import { News } from "../office/news/News";
import "./style.scss"

const App = () => {
  return (
    <BrowserRouter>
      <div className="wrapper">
        <Layout />
        <Routes>
          <Route path='/' element={<StartPage />} />
          <Route path="/login" element={ <Login /> } />
          <Route path="/home" element={ <HomePage /> } />
          <Route path="/register" element={ <Register /> } />
          <Route path="/list" element={ <PlayerList /> } />
          <Route path="/office" element= { <Office /> } >
            <Route path='profile' element={ <Profile /> } />
            <Route path='news' element={ <News /> } />
          </Route>
        </Routes>
      </div>
    </BrowserRouter>
  )
}

export default App;