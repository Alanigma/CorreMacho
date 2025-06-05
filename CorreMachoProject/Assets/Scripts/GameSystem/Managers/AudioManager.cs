using MigalhaSystem.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameSystem
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] List<AudioSource> m_musics;
        int m_currentMusicIndex;

        private void Start()
        {
            m_currentMusicIndex = Random.Range(0, m_musics.Count);
            GetCurrentMusic().Play();
            StartCoroutine(MusicUpdate());
        }

        IEnumerator MusicUpdate()
        {
            yield return new WaitForSecondsRealtime(GetCurrentMusic().clip.length);
            GetCurrentMusic().Stop();
            NextSong();
            StartCoroutine(MusicUpdate());
        }

        public AudioSource GetCurrentMusic()
        {
            return m_musics[m_currentMusicIndex];
        }

        void NextSong()
        {
            GetCurrentMusic().Stop();
            m_currentMusicIndex++;
            if (m_currentMusicIndex >= m_musics.Count)
            {
                m_currentMusicIndex = 0;
            }
            GetCurrentMusic().Play();
        }
    }
}
