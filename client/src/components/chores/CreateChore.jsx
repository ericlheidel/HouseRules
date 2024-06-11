import { useState } from "react"
import { Button, Form, FormFeedback, FormGroup, Input, Label } from "reactstrap"
import { createChore } from "../../managers/choreManager.js"
import { useNavigate } from "react-router-dom"

export const CreateChore = () => {
  const [choreName, setChoreName] = useState("")
  const [difficulty, setDifficulty] = useState(0)
  const [frequency, setFrequency] = useState(0)

  const [difficultyValid, setDifficultyValid] = useState(null)

  const navigate = useNavigate()

  const handleSubmit = (e) => {
    e.preventDefault()

    const newChore = {
      name: choreName,
      difficulty: parseInt(difficulty),
      choreFrequencyDays: parseInt(frequency),
    }

    if (choreName === "" || difficulty === 0 || frequency === 0) {
      window.alert("Please fill out all fields")
    } else {
      createChore(newChore).then(() => {
        navigate("/chores")
      })
    }
  }

  const handleChoreNameChange = (e) => {
    setChoreName(e.target.value)
  }

  const handleDifficultyChange = (e) => {
    setDifficulty(e.target.value)

    if (e.target.value < 1 || e.target.value > 5) {
      setDifficultyValid(false)
    } else {
      setDifficultyValid(true)
    }
  }
  const handleFrequencyChange = (e) => {
    setFrequency(e.target.value)
  }

  return (
    <Form>
      <FormGroup>
        <Label for="chore">Chore</Label>
        <Input id="chore" onChange={handleChoreNameChange} />
      </FormGroup>
      <FormGroup>
        <Label for="difficulty">Difficulty Level (1 - 5)</Label>
        <Input
          type="number"
          id="difficulty"
          // valid={difficultyValid === true}
          invalid={difficultyValid === false}
          onChange={handleDifficultyChange}
        />
        <FormFeedback valid>
          You chosen a difficulty level of {difficulty}
        </FormFeedback>
        <FormFeedback invalid>
          Please Enter a Number between 1 and 5
        </FormFeedback>
      </FormGroup>
      <FormGroup>
        <Label for="frequency">Chore Frequency (# of Days)</Label>
        <Input type="number" id="frequency" onChange={handleFrequencyChange} />
      </FormGroup>
      <FormGroup>
        <Button type="submit" color="primary" onClick={handleSubmit}>
          Submit
        </Button>
      </FormGroup>
    </Form>
  )
}
