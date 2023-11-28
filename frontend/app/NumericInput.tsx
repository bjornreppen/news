import { Dispatch, EventHandler, SetStateAction } from "react"

interface Props {
  title: string
  subtitle: string
  value: string
  onChangeValue: Dispatch<SetStateAction<string>> //(value: string) => {}
}

export default function NumericInput(
  { title, subtitle, value, onChangeValue }:Props
) {
  const handleChangeValue = (e:React.ChangeEvent<HTMLInputElement>) => {
    console.log(e.target.value)
    onChangeValue(e.target.value)
  }
  return (
    <div className="w-[404px] h-[99px] flex-col justify-start items-start gap-3 inline-flex">
      <div className="h-[46px] flex-col justify-start items-start gap-2 flex">
        <div className="text-black text-base font-semibold font-['Inter'] leading-tight">{title}</div>
        <div className="self-stretch text-black text-sm font-normal font-['Inter']">{subtitle}</div>
      </div>
      <input type="number" onChange={handleChangeValue} value={value}></input>
    </div>
  )
}
