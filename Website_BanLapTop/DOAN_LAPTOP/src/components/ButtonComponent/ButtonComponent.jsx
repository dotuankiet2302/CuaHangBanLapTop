import React from 'react'
import {Button} from 'antd'
const ButtonComponent = ({size, icon, style, textButton, styleTextButton,...rests}) => {
  return (
    <Button
    size={size}
    icon={icon}
    style={style}
   {...rests}
>
    <span style={styleTextButton}>{textButton}</span>
</Button>
  )
}

export default ButtonComponent