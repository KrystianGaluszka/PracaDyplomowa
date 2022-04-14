import react from "react";
import { Outlet } from "react-router-dom";
import '../../shared/subPageHelper.scss'


export const Team = () => {
    return(
    <div className="team-container scrollable">
        <Outlet />
    </div>)
}