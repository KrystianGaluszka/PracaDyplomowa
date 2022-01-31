import react from "react";
import { Outlet } from "react-router-dom";
import '../../shared/subPageHelper.scss'


export const Office = () => {
    return(
    <div className="office-container scrollable">
        <Outlet />
    </div>)
}