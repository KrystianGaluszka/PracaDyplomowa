import react from 'react'

export const ModalRow = (props: { title:string, content: any, color?: string }) => {
    return(
       <div className='row'>
           <div className='row--title'>
               {props.title}:
           </div>
           <div className='row--content'>
                {props.color !== undefined ? 
                <div className='rarity' style={{color: props.color}}>
                   {props.content}
                </div> :
                <span>
                    {props.content}
                </span>}
           </div>
       </div>
    )
}