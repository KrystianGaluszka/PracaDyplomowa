import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { IItem, IUser } from '../../../shared/interfaces'
import { BsCurrencyDollar } from 'react-icons/bs'
import './style.scss'
import { Form, Modal } from 'react-bootstrap'


export const Shop = ({user}: {user: IUser}) => {
    const [items, setItems] = useState<IItem[]>([])
    const [show, setShow] = useState(false)
    const [clickedItem, setClickedItem] = useState<IItem>()
    const [itemCount, setItemCount] = useState(0)

    useEffect(() => {
        const getItems = async () => {
            await axios('https://localhost:44326/api/Item')
                .then(res => {
                    setItems(res.data)
                })
                .catch(error => console.log(error))
        }

        getItems()
    }, [])

    const handleShowModal = (itemName: string) => {
        setShow(true)
        const item = items.find(x => x.name === itemName)
        setClickedItem(item)
    }

    const handleCloseModal = () => setShow(false)

    const onClickBuy = async () => {
        const userId = user.id
        const itemId = clickedItem?.id
        const count = itemCount
        const data = {userId, itemId, count}

        let apiError: any
        let response: any
        await axios.put('https://localhost:44326/api/Item/additem', data)
            .then(res => response = res.data)
            .catch(error => {
                apiError = error
            })

        if(response === 'success') {
            setShow(false)
        }
    }

    const handleInput = (e: any) => {
        const value = e.target.value
        setItemCount(value)
    }

    return (
        <div className='shop-container'>
            <div className='items-container'>
                <div className='items-table'>
                    {items.map((item: IItem) => {
                        return (
                        <div className='item-container' key={item.id}>
                            <button className='item-icon' disabled={user.money <= item.price}  onClick={() => handleShowModal(item.name)}>
                                <img src={item.iconPath} />
                                <div className='price'>
                                    <img src='https://localhost:44326/images/shopIcons/coin.png' />
                                    {item.price}
                                </div>
                                <div className='buy' >
                                    <BsCurrencyDollar />
                                </div>
                            </button>
                            <div className='item-description'>
                                {item.description}
                            </div>
                        </div>
                        )
                    })}
                </div>
            </div>
            <Modal dialogClassName='shop-modal' show={show} onHide={handleCloseModal}>
                <Modal.Body className='popup-body'>
                    <div className='body-content'>
                        <div className='buy-container'>
                            <div className='item-value'>
                                <Form.Control
                                    className='input-number'
                                    type='number'
                                    dir="rtl"
                                    min='0'
                                    max={user.money/clickedItem?.price!}
                                    size='sm'
                                    placeholder='0'
                                    onChange={ e => handleInput(e) }
                                />
                            </div>
                            <div className='item-btn'>
                                <button className='btn-blue buy-btn' onClick={onClickBuy} >Buy</button>
                            </div>
                        </div>
                    </div>
                </Modal.Body>
            </Modal>
        </div>
    )
}