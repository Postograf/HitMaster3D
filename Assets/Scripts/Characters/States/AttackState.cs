using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class AttackState : State
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _distanceToTargetPlane;
    [SerializeField] private float _bulletSpeed;

    private Camera _camera;

    private void OnEnable()
    {
        StateMachine.Animator.SetTrigger("idle");
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            var cameraRay = _camera.ScreenPointToRay(Input.GetTouch(0).position);
            var camDirection = _camera.transform.forward;
            var camPosition = _camera.transform.position;
            var planePosition = camPosition + camDirection * _distanceToTargetPlane;
            var targetPlane  = new Plane(-camDirection, planePosition);

            if (targetPlane.Raycast(cameraRay, out float length))
            {
                var shotTarget = cameraRay.GetPoint(length);
                var shotDirection = shotTarget - _firePoint.position;

                BulletSpawner.Instance.Get(
                    _firePoint.position, shotDirection.normalized, _bulletSpeed
                );
            }
        }
    }
}
