interface Props {
    score?: string;
}

export default function NewsScore(
    { score }: Props
) {
    if (!score) return null
    return (
        <div className="w-[404px] h-[58px] p-4 bg-purple-50 rounded-[10px] border border-violet-700 border-opacity-40 justify-start items-center gap-4 inline-flex">
            <div className="grow shrink basis-0 flex-col justify-start items-start gap-2 inline-flex">
                <div className="self-stretch"><span className="text-indigo-950 text-xl font-normal font-['Inter'] leading-relaxed">News score: </span><span className="text-indigo-950 text-xl font-semibold font-['Inter'] leading-relaxed">{score}</span></div>
            </div>
        </div>)
}
