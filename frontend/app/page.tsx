"use client"

import NumericInput from './NumericInput'
import Button from './Button'
import { useState } from 'react'
import NewsScore from './NewsScore'

export default function Home() {
  const [bodyTempCelsius, setBodyTempCelsius] = useState<string>('')
  const [heartRateBps, setHeartRateBps] = useState<string>('')
  const [respiratoryRateBps, setRespiratoryRateBps] = useState<string>('')
  const [newsScore, setNewsScore] = useState<string>()

  const handleReset = () => {
    setBodyTempCelsius('')
    setHeartRateBps('')
    setRespiratoryRateBps('')
    setNewsScore('')
  }

  const handleCalculate = async () => {
    console.log("?=====")
    const body = {
      measurements: [
        { type: "TEMP", value: parseFloat(bodyTempCelsius) },
        { type: "HR", value: parseFloat(heartRateBps) },
        { type: "RR", value: parseFloat(respiratoryRateBps) },
      ]
    }
    const body2 = 
        { type: "TEMP", value: 22}// parseFloat(bodyTempCelsius) }
    console.log(body2)
    var r = await fetch("http://localhost:5000/api/news", 
      {
        method: "POST", 
        headers: {
          "Content-Type": "application/json",
        },        
        body: JSON.stringify(body)
      })
      setNewsScore(await r.text())
  }

  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
main className="w-[404px] h-[641px] flex-col justify-start items-start gap-10 inline-flex"

<div className="text-black text-xl font-semibold font-['Inter'] xleading-relaxed">NEWS score calculator</div>

      <NumericInput title="Body temperature" subtitle="Degrees celcius" value={bodyTempCelsius} onChangeValue={setBodyTempCelsius} />
      <NumericInput title="Heartrate" subtitle="Beats per minute" value={heartRateBps} onChangeValue={setHeartRateBps} />
      <NumericInput title="Respiratory rate" subtitle="Breaths per minute" value={respiratoryRateBps} onChangeValue={setRespiratoryRateBps} />
      <Button color="primary" title="Calculate NEWS score" onClick={handleCalculate} />
      <Button color="secondary" title="Reset form" onClick={handleReset} />
      <NewsScore score={newsScore} />
    </main>
  )
}
