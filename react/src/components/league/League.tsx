import react from "react";
import { Outlet } from "react-router-dom";
import '../../shared/subPageHelper.scss'


export const League = () => {
    return(
    <div className="league-container scrollable">
        <Outlet />
    </div>)
}