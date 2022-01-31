import "./style.scss";
import { Login } from "./login";
import { Register } from "./register";
import { useState } from "react";

export const Account = (props: any) => {

    const [isLogginActive, setIsLogginActive] = useState(true)

    return (
        <div className="container">
            { isLogginActive && <Login /> }
            { !isLogginActive && <Register /> }
        </div>

    )
}