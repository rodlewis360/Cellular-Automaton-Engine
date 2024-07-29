 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridNoiseReader : MonoBehaviour
{
    public string readButton;

    public int bpm;

    public GridBehavior grid;

    bool playing = false;

    List<AudioSource> notes;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(readButton) && !playing)
        {
            StartCoroutine(playNotes());
            playing = true;
        }
    }

    IEnumerator playNotes()
    {
        for (int x = 0; x < grid.gridSizeX; x++)
        {
            notes = new List<AudioSource>();
            for (int y = 0; y < grid.gridSizeY; y++)
            {
                if (grid.grid[x, y].GetComponent<Cell>().state > 0)
                {
                    notes.Add(grid.grid[x, y].GetComponent<IRuleNoise>().note);
                }
            }
            foreach (AudioSource a in notes)
            {
                a.Play();
            }

            yield return new WaitForSeconds(1/(bpm/60));
        }
        playing = false;
    }
}
