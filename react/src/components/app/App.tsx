import React from "react";
import { Login } from "../registerAndLogin/Login";
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { Layout } from "../layout/Layout";
import { Register } from "../registerAndLogin/Register";
import { StartPage } from "../startPage/StartPage";
import "./style.scss"

const App = () => {
  return (
    <BrowserRouter>
      <div className="wrapper">
        <Layout />
        <Routes>
            <Route path='/' element={<StartPage />} />
            <Route path="/login" element={ <Login /> } />
            <Route path="/register" element={ <Register /> } />
        </Routes>
      </div>
    </BrowserRouter>
    
  )
}

export default App;