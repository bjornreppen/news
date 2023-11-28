interface Props {
  title: string;
  color: string;
  onClick: () => void
}

export default function Button(
  { title, color, onClick }: Props
) {
  const bg = color === "primary" ? 'bg-violet-700' : 'bg-purple-50'
  const fg = color === "primary" ? 'text-white' : 'text-black'
  return (
    <button className={"px-4 py-2 rounded-[40px] justify-center items-center gap-3 flex " + bg} onClick={onClick}>
      <div className={"text-base font-normal font-['Inter'] leading-normal " + fg}>{title}</div>
    </button>
  )
}
