import react, { useEffect, useState } from "react";
import { Outlet } from "react-router-dom";
import { IUser, IUsersItems } from "../../shared/interfaces";
import '../../shared/subPageHelper.scss'
import './financesStyle.scss'

export const Finances = ({user}: {user: IUser}) => {
    const [useEffectRender, setUseEffectRender] = useState(false)
    const [userContracts, setUserContracts] = useState(0)
    const [userMedKits, setUserMedKits] = useState(0)
    const [userBoosts, setUserBoosts] = useState(0)
    const [userChests, setUserChests] = useState(0)

    useEffect(() => {
        let interval: any = null;
        interval = setInterval(() => {
            setUseEffectRender(render => !render) // rerender useEffecta co 1s
          }, 1000)

        const getItems = async () => {
            let chestCount = 0
            user.usersItems.map((item: IUsersItems) => {
                
                switch(item.item.name) {
                    case 'Contracts':
                        setUserContracts(item.count)
                        break
                    case 'Med-Kit':
                        setUserMedKits(item.count)
                        break
                    case 'XP-Boost':
                        setUserBoosts(item.count)
                        break
                }

                if(item.item.name.includes('chest')) {
                    chestCount += item.count
                }
            })
            setUserChests(chestCount)
        }

        getItems()

        return () => clearInterval(interval);
    }, [useEffectRender])

    return(
    <div className="finances-container scrollable">
        <div className='user-currency'>
                <div className='currency-container'>
                    <div className='icon'><img src='https://localhost:44326/images/shopIcons/coin.png' /></div>
                    <div className='value'>{user.money}</div>
                </div>
                <div className='currency-container'>
                    <div className='icon'><img src='https://localhost:44326/images/shopIcons/contract.png' /></div>
                    <div className='value'>{userContracts}</div>
                </div>
                <div className='currency-container'>
                    <div className='icon'><img src='https://localhost:44326/images/shopIcons/med-kit-clear.png' /></div>
                    <div className='value'>{userMedKits}</div>
                </div>
                <div className='currency-container'>
                    <div className='icon'><img src='https://localhost:44326/images/shopIcons/chest.png' /></div>
                    <div className='value'>{userChests}</div>
                </div>
                <div className='currency-container'>
                    <div className='icon'><img src='https://localhost:44326/images/shopIcons/xp-boost-clear.png' /></div>
                    <div className='value'>{userBoosts}</div>
                </div>
            </div>
        <Outlet />
    </div>)
}