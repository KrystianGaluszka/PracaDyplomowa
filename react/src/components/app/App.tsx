import React, { useState } from "react";
import { Account } from "./../account";
import { Login } from "./../registerAndLogin/Login";
import { BrowserRouter, Link, Route, Routes } from 'react-router-dom'
import HomePage from "../homepage/HomePage";
import '../../../node_modules/bootstrap/dist/css/bootstrap.min.css'
import { Layout } from "../layout/Layout";

const App = () => {

  const [token, setToken] = useState();

  // if (!token) {
  //   return <Login setToken={ setToken } />
  // }

  return (
    <BrowserRouter>
      <div className="wrapper">
        <Layout />
        <Routes>
          <Route path="/login" element={ <Login /> } />
          <Route path="/home" element={ <HomePage /> } />
        </Routes>
      </div>
    </BrowserRouter>
  )
}

export default App;