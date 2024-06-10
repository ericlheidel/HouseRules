import { useEffect, useState } from "react"
import { getChores } from "../../managers/choreManager.js"
import { Card } from "reactstrap"

export const ChoresList = () => {
  const [chores, setChores] = useState([])

  useEffect(() => {
    getChores().then(setChores)
  }, [])

  return (
    <div>
      {chores.map((c) => {
        return (
          <Card key={c.id}>
            <h2>
              <u>{c.name}</u>
            </h2>
            <h3>
              Difficulty{" - "}
              <b>
                {c.difficulty == 1 && "Easy"}
                {c.difficulty == 2 && "Easy-Medium"}
                {c.difficulty == 3 && "Medium"}
                {c.difficulty == 4 && "Medium-Hard"}
                {c.difficulty == 5 && "Hard"}
              </b>
            </h3>
            <h3>
              Frequency{" - "}
              {c.choreFrequencyDays}
              {c.choreFrequencyDays == 1 ? " Day" : " Days"}
            </h3>
          </Card>
        )
      })}
    </div>
  )
}
