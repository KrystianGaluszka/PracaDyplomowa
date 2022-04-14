import { Table, TableBody, TableCell, TableRow } from "@mui/material";
import React from "react";
import { Droppable, Draggable } from "react-beautiful-dnd";
import { IUsersPlayer } from "../../../shared/interfaces";
import { BsPlusLg } from 'react-icons/bs'

interface Props {
  players: IUsersPlayer[];
  listId: string;
  listType?: string;
  internalScroll?: boolean;
  isCombineEnabled?: boolean;
  parentCallBack?: any;
}

export const PlayerLists: React.FC<Props> = ({ listId, listType, players, parentCallBack }) => {


  return (
    <Droppable
      droppableId={listId}
      type={listType}
      direction="vertical"
      isCombineEnabled={false}
    >
      {dropProvided => (
          <Table className='table player-list-table' {...dropProvided.droppableProps}>
            <TableBody className='table-body table-body-settings' ref={dropProvided.innerRef}>
                {players.filter(x=> x.usersPlayerState.isOnAuction === false).map((player: IUsersPlayer, index) => {
                    let color = ''
                    switch(player.player.rarity) {
                      case 'Common':
                        color = 'grey'
                        break;
                      case 'Uncommon':
                        color = '#00dd00'
                        break;
                      case 'Rare':
                        color = '#07dcf8'
                        break;
                      case 'Epic':
                        color = '#cb00dd'
                        break;
                      case 'Masterwork':
                        color = '#dd8500'
                        break;
                      case 'Legendary':
                        color = '#ccc01b'
                        break;
                    }
                    return (
                    <Draggable key={player.id} draggableId={(player.id).toString()} index={index} >
                      {dragProvided => (
                        <TableRow
                            className="table-body-row player-list-table-row"
                            {...dragProvided.dragHandleProps}
                            {...dragProvided.draggableProps}
                            ref={dragProvided.innerRef}>
                            <TableCell align='center' className='table-body-cell' ><div style={{ borderColor: color}} className='level'>{player.level}</div></TableCell>
                            <TableCell align='center' className='table-body-cell'>{player.player.name}</TableCell>
                            <TableCell align='center' className='table-body-cell'>{player.player.surname}</TableCell>
                            <TableCell align='left' className='table-body-cell'>{player.player.position}</TableCell>
                            <TableCell align='center' className='table-body-cell icon captain-cell' onClick={() => parentCallBack(player.id)}>
                              {player.usersPlayerState.isCaptain ?
                              <button id='captainBtn' className="captain-btn" onClick={() => parentCallBack(player.id)}>C</button> :
                              <BsPlusLg className='plus-icon'/>}
                            </TableCell>
                        </TableRow>
                      )}
                    </Draggable>
                    )
                  })}
                {dropProvided.placeholder}
            </TableBody>
          </Table>         
      )}
    </Droppable>
  );
};