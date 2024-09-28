import React from 'react'
import { WrapperContent, WrapperLableText, WrapperTextPrice, WrapperTextValue } from './style'
import { Checkbox, Col, Rate, Row } from 'antd'

const NavBarComponent = () => {
    const onChange=()=>{}
    const renderContent=(type, options)=>{
        switch(type){
            case 'text':
                return options.map((option)=>{
                   return(
                    <WrapperTextValue>{option}</WrapperTextValue>
                   )
                })
            case 'checkbox':
                return (
                    <Checkbox.Group style={{ width: '100%', display: 'flex',gap: '12px', flexDirection: 'column'}} onChange={onChange}>
                        {options.map((option)=>{
                            return(
                                <Checkbox style={{marginLeft: 0}} value={option.value}>{option.lable}</Checkbox>
                            )
                        })}
        
             </Checkbox.Group>
                )
                case 'star':
                    return options.map((option)=>{
                        console.log('check', option)
                                return(
                                    <div style={{display: 'flex', gap: '4px'}}>
                                         <Rate allowHalf defaultValue={option} />
                                         <span>{`từ ${option} sao`}</span>
                                    </div>
                                   
                                )
                            })
                case 'price':
                    return options.map((option)=>{
                        return (
                            <WrapperTextPrice>{option}</WrapperTextPrice>
                        )
                         })
            default:
                return {}
        }
    }
  return (
    <div>
        <WrapperLableText>NavBarComponent</WrapperLableText>
       <WrapperContent>
            {renderContent('text',['Shirt', 'Trousers', 'Dress'])}
        </WrapperContent>
        <WrapperContent>
            {renderContent('checkbox',[{value: 'a', lable: 'A'},
                {value: 'b', lable: 'B'}
            ])}
        </WrapperContent>
        <WrapperContent>
            {renderContent('star',[2,3,4])}
        </WrapperContent>
        <WrapperContent>
            {renderContent('price',['Dưới 500.000',' Trên 500.00'])}
        </WrapperContent>
    </div>
  )
}

export default NavBarComponent