import react from 'react'

export const StartPage = () => {
    var path = 'https://localhost:44326/images/'
    return(
        <div>
            <img src={path + 'players.jpg'} width={150} height={150}/>
            <div></div>
            <a href='/login'>login</a>
            <div></div>
            <a href='/register'>register</a>
        </div>
    )
}