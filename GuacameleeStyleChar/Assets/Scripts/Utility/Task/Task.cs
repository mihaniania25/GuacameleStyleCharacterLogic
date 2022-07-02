using UnityEngine;
using System.Collections;

namespace GuacameleeStyleChar.Utility
{
	public class Task
	{
		private Coroutine _coroutine;
		private static CoroutineRunner _coroutineRunner;

		public Task(IEnumerator c)
		{
			_coroutine = _runner.StartCoroutine(c);
		}

		public void Stop()
		{
			if (_coroutine != null && _coroutineRunner != null && _coroutineRunner.gameObject != null)
				_coroutineRunner.StopCoroutine(_coroutine);
		}

		private CoroutineRunner _runner
		{
			get
			{
				if (_coroutineRunner == null)
				{
					GameObject runnerGO = new GameObject("CoroutineRunner");
					_coroutineRunner = runnerGO.AddComponent<CoroutineRunner>();
					GameObject.DontDestroyOnLoad(_coroutineRunner);
				}

				return _coroutineRunner;
			}
		}
	}
}