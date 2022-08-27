using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [Serializable]
    public class WidgetWithStates
    {
        [SerializeField] protected Image m_Image;
    
        [SerializeField] private Sprite m_NormalState;
        [SerializeField] private Sprite m_FocusState;

        public virtual void Focus()
        {
            SetSpriteInternal(m_FocusState);
        }

        public virtual void UnFocus()
        {
            SetSpriteInternal(m_NormalState);
        }

        private void SetSpriteInternal(Sprite sprite)
        {
            if(m_Image is null || sprite is null)
                return;

            m_Image.sprite = sprite;
        }
    }

    [Serializable]
    public class WidgetWithStatesAndTint : WidgetWithStates
    {
        [SerializeField] private Color m_NormalColor;
        [SerializeField] private Color m_FocusColor;

        public override void Focus()
        {
            base.Focus();
            SetColorInternal(m_FocusColor);
        }

        public override void UnFocus()
        {
            base.UnFocus();
            SetColorInternal(m_NormalColor);
        }

        private void SetColorInternal(Color color)
        {
            if(m_Image is null)
                return;
            m_Image.color = color;
        }
    }

    [Serializable]
    public class WidgetStatesWithScale : WidgetWithStatesAndTint
    {
        [SerializeField] private float m_NormalScale;
        [SerializeField] private float m_FocusScale;
        
        public override void Focus()
        {
            base.Focus();
            SetScaleInternal(m_FocusScale);
        }

        public override void UnFocus()
        {
            base.UnFocus();
            SetScaleInternal(m_NormalScale);
        }

        private void SetScaleInternal(float scale)
        {
            if(m_Image is null)
                return;
            
            m_Image.rectTransform.localScale = new Vector3(scale, scale, scale);
        }
    }
}