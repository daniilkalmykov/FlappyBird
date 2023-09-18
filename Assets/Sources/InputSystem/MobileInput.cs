using UnityEngine;

namespace Sources.InputSystem
{
    internal sealed class MobileInput : IInput
    {
        public bool IsJumpButtonClicked { get; private set; }

        public void Update()
        {
            if (Input.touchCount <= 0)
            {
                IsJumpButtonClicked = false;
                return;
            }

            foreach (var touch in Input.touches)
                IsJumpButtonClicked = touch.phase == TouchPhase.Began;
        }
    }
}
